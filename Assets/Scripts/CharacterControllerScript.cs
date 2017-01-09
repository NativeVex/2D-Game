using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {


	//public Rigidbody rb;
	public float speed = 10.0f;
	public int lastDirection = 1;
	Animator anim;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	// Use this for initialization

	void Start () {
		//rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
// Use input up and down for direction, multiplied by speed
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;
		controller.Move (moveDirection * Time.deltaTime);

	
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			anim.SetInteger ("Direction", 1);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			anim.SetInteger ("Direction", 2);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			anim.SetInteger ("Direction", 3);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			anim.SetInteger ("Direction", 4);
		} 
		else {
			print ("q");
		}

	}



	void LateUpdate(){
		moveDirection = new Vector3 (0,0,0);
		controller.Move (moveDirection * Time.deltaTime);
		//transform.position.z = 0;
	}
}
