using UnityEngine;
using System.Collections;


public class CharacterControl : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    public float attackScale;
    Animator animator;
    Animator attackAnim;
	public GameObject Attack;
    //animation states - the values in the animator conditions
    const int DIR_FRONT = 0, DIR_BACK = 1, DIR_RIGHT = 2, DIR_LEFT =3;
	public int dir;
	bool walking, run, attack, ded = false; //write to ded only when dead
    public int dmg;

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
		animator = gameObject.transform.GetComponentInChildren<Animator>();
        attackAnim = Attack.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().position = new Vector3
            (Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.x, xMin, xMax),
             gameObject.GetComponent<Rigidbody>().position.y,
             Mathf.Clamp(gameObject.GetComponent<Rigidbody>().position.z, zMin, zMax));
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update()
    {
        //is dead?
        
        if (gameObject.GetComponent<HP>().GetHealth() <= 0) {
               ded = true;
               //WaitUntil (animator.IsInTransition); //if looping is a transition?
               Debug.Log ("bleh i'm dead");
           } 

        //is running?
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            run = true;
        }
        //Attack section, piggybacks off of animation states for attack dir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Quaternion right = Quaternion.FromToRotation (Vector3.forward, Vector3.right);
            //Quaternion left = Quaternion.FromToRotation(Vector3.forward, Vector3.left);
            //Quaternion full = Quaternion.FromToRotation(Vector3.forward, Vector3.back);
            switch (dir)
            {
                case 0:
					new AttackBundle(new string[] {
	                    "AI",
	                    "Player"
				}, 5, 0, runSpeed,Attack,gameObject, attackScale);
                    break;
                case 1:
					new AttackBundle(new string[] {
						"AI",
						"Player"
				}, 5,1, runSpeed,Attack,gameObject, attackScale);
                    break;
                case 2:
					new AttackBundle(new string[] {
						"AI",
						"Player"
				}, 5, 2, runSpeed,Attack,gameObject, attackScale);
                    break;
                case 3:
					new AttackBundle(new string[] {
						"AI",
						"Player"
				}, 5, 3, runSpeed,Attack,gameObject, attackScale);
                    break;
            }
            attack = true;
        }

        //direction section
        if (Input.GetKey(KeyCode.W))
        {
            walking = true;
            dir = DIR_BACK;
            if (run)
            {
                transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            } 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            walking = true;
            dir = DIR_LEFT;
            if (run)
            {
                transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            } 
        }
        else if (Input.GetKey(KeyCode.S))
        {
            walking = true;
            dir = DIR_FRONT;
            if (run)
            {
                transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            } 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            walking = true;
            dir = DIR_RIGHT;
            if (run)
            {
                transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            } 
        }
        else
        {
            walking = false;
        }
        animator.SetInteger("Dir", dir); //it's Dir and not dir cause i'm retarded and not about to reconfigure the entire web
        animator.SetBool("walking", walking);
        animator.SetBool("run", run);
        animator.SetBool("ded", ded);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Enemy"))
        {
            gameObject.GetComponent<HP>().health -= dmg;
        }
    }
   }


   

