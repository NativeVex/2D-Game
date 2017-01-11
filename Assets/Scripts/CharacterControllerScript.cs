using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {

	private Vector3 moveD = new Vector3 (0, 0, 0);

	//sprite sorting order
	public const string LAYER_NAME = "TopLayer";
	public int sortingOrder = 0;
	private SpriteRenderer sprite;

	//movement variables
	public float speed = 10.0f;
	public Vector3 playerPos;
	public int lastDirection = 1;
	Animator anim;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;

	//dash
	public float MaxDashTime = 0.1f;
	public float dashSpeed = 5.0f;
	public float dashStoppingSpeed = 0.01f;
	private float currentDashTime;

	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		if (sprite)
		{
			sprite.sortingOrder = sortingOrder;
			sprite.sortingLayerName = LAYER_NAME;
		}
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
		currentDashTime = MaxDashTime;
	}
	
	// Update is called once per frame
	void Update () {
		//dashing
		print(lastDirection);
		if (Input.GetKeyDown(KeyCode.Q))
		{
			currentDashTime = 0.0f;
		}

		if (currentDashTime < MaxDashTime)
		{
			
			switch (lastDirection) {
			case 1:
				moveDirection = new Vector3 (0, Input.GetAxis ("Vertical") - dashSpeed, 0);
				currentDashTime += dashStoppingSpeed;
				break;
			case 2:
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal") - dashSpeed, 0, 0);
				currentDashTime += dashStoppingSpeed;
				break;
			case 3:
				moveDirection = new Vector3 (0, Input.GetAxis ("Vertical") + dashSpeed, 0);
				currentDashTime += dashStoppingSpeed;
				break;
			case 4:
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal") + dashSpeed, 0, 0);
				currentDashTime += dashStoppingSpeed;
				break;
			}
		}

		else
		{
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		}



	
		if (Input.GetKeyDown ("down")) {
			anim.SetInteger ("Direction", 1);
				lastDirection = 1;
		}
		if (Input.GetKeyDown ("left")) {
			anim.SetInteger ("Direction", 2);
				lastDirection = 2;
		}
		if (Input.GetKeyDown ("up")) {
			anim.SetInteger ("Direction", 3);
				lastDirection = 3;
		}
		if (Input.GetKeyDown ("right")) {
			anim.SetInteger ("Direction", 4);
				lastDirection = 4;
		} 
		Move ();


	}
	void Move(){
		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		//moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);
		playerPos = moveDirection;
		print (playerPos);
	}



	void LateUpdate(){
		
		moveD = new Vector3 (0,0,0);
		controller.Move (moveD * Time.deltaTime);
	}
}
