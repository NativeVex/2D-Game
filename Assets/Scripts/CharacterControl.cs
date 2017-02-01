using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    Animator animator;
    Animator attackAnim;

    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT = 2, DIR_RIGHT = 3;
    public bool ATTACK = false, DEAD = false, WALK = false;

    //animation states - the values in the animator conditions
    const int DIR_FRONT = 0, DIR_BACK = 1, DIR_RIGHT = 2, DIR_LEFT =3;
	int dir;
	bool walking, run, attack, ded = false; //write to ded only when dead

	void attackBundle(Vector3 dir, float magnitude, GameObject AttackPrefab, string[] tags){
		GameObject VisualAttack = (GameObject)Instantiate (AttackPrefab,gameObject.transform.position,Quaternion.identity);
		//Debug.Log ("childcount = "+VisualAttack.transform.childCount);
		Vector3 velocity = VisualAttack.GetComponent<Rigidbody>().velocity;
		velocity = dir * magnitude;
	}

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
		animator = gameObject.transform.GetComponentInChildren<Animator>();
        attackAnim = Attack.GetComponent<Animator>();
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update(){
		//is dead?
		if (gameObject.GetComponent<HP> ().health <= 0) {
			ded = true;
			//WaitUntil (animator.IsInTransition); //if looping is a transition?
			Debug.Log ("bleh i'm dead");
		}

		//is running?
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			run = true;
		}
		//Attack section, piggybacks off of animation states for attack dir
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Quaternion right = Quaternion.FromToRotation (Vector3.forward, Vector3.right);
			Quaternion left = Quaternion.FromToRotation (Vector3.forward, Vector3.left);
			Quaternion full = Quaternion.FromToRotation (Vector3.forward, Vector3.back);
			switch (dir) {
			case 0:
				attackBundle (Vector3.forward, 5, Attack, new string[] {
					"AI",
					"Player"
				});
				break;
			case 1:
				attackBundle (Vector3.back, 5, Attack, new string[] {
					"AI",
					"Player"
				});
				break;
			case 2:
				attackBundle (Vector3.right, 5, Attack, new string[] {
					"AI",
					"Player"
				});
				break;
			case 3:
				attackBundle (Vector3.left, 5, Attack, new string[] {
					"AI",
					"Player"
				});
				break;
			}
			attack = true;
		}

		//direction section
		if (Input.GetKey (KeyCode.W)) {
			walking = true;
			dir = DIR_FRONT;
			if (run) {
				transform.Translate (Vector3.forward * runSpeed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.forward * walkSpeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.A)) {
			walking = true;
			dir = DIR_LEFT;
			if (run) {
				transform.Translate (Vector3.left * runSpeed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.S)) {
			walking = true;
			dir = DIR_BACK;
			if (run) {
				transform.Translate (Vector3.back * runSpeed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.back * walkSpeed * Time.deltaTime);
			}
		} else if (Input.GetKey (KeyCode.D)) {
			walking = true;
			dir = DIR_RIGHT;
			if (run) {
				transform.Translate (Vector3.right * runSpeed * Time.deltaTime);
			} else {
				transform.Translate (Vector3.right * walkSpeed * Time.deltaTime);
			}
		} else {
			walking = false;
		}
		animator.SetInteger ("Dir", dir); //it's Dir and not dir cause i'm retarded and not about to reconfigure the entire web
		animator.SetBool ("walking", walking);
		animator.SetBool ("run", run);
		animator.SetBool ("ded", ded);
	}





//        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Left
//        {
//            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
//			dir = DIR_LEFT;
//			run = true;
//			attack = false;
//        }
//        else if (Input.GetKey(KeyCode.LeftArrow))   //Walk Left
//        {
//            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
//			dir = DIR_LEFT;
//			run = false;
//			ded = false;
//			attack = false;
//        }
//        if (Input.GetKeyUp(KeyCode.LeftArrow))  //Left Idle
//        {
//            changeState(STATE_LEFT_IDLE);
//        }
//
//        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Right
//        {
//            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
//            changeState(STATE_WALKRIGHT);
//        }
//        else if (Input.GetKey(KeyCode.RightArrow))  //Walk Right
//        {
//            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
//            changeState(STATE_WALKRIGHT);
//        }
//        if (Input.GetKeyUp(KeyCode.RightArrow)) //Right Idle
//        {
//            changeState(STATE_RIGHT_IDLE);
//        }
//
//        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
//        {
//            transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
//            changeState(STATE_WALKUP);
//        }
//        else if (Input.GetKey(KeyCode.UpArrow))   //Walk Up
//        {
//            transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
//            changeState(STATE_WALKUP);
//        }
//        if (Input.GetKeyUp(KeyCode.UpArrow))  //Up Idle
//        {
//            changeState(STATE_BACK_IDLE);
//        }
//
//        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
//        {
//            transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
//            changeState(STATE_WALKDOWN);
//        }
//        else if (Input.GetKey(KeyCode.DownArrow))  //Walk Down
//        {
//            transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
//            changeState(STATE_WALKDOWN);
//        }
//        if (Input.GetKeyUp(KeyCode.DownArrow))  //Down Idle
//        {
//            changeState(STATE_FRONT_IDLE);
//        }
//    }

    }


    void changeState(int state, bool walk)

        transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
        if (state != _currentAnimationState)
        {
            animator.SetInteger("Dir", state);
        }
    } */

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
//    void changeState(int state)
//    {
//
//        if (_currentAnimationState == state)
//            return;
//
//        switch (state)
//        {
//
//            case STATE_WALKUP:
//                animator.SetInteger("State", STATE_WALKUP);
//                direction = "up";
//                break;
//
//            case STATE_WALKDOWN:
//                animator.SetInteger("State", STATE_WALKDOWN);
//                direction = "down";
//                break;
//
//            case STATE_WALKLEFT:
//                animator.SetInteger("State", STATE_WALKLEFT);
//                direction = "left";
//                break;
//
//            case STATE_WALKRIGHT:
//                animator.SetInteger("State", STATE_WALKRIGHT);
//                direction = "right";
//                break;
//
//            case STATE_FRONT_IDLE:
//                animator.SetInteger("State", STATE_FRONT_IDLE);
//                direction = "down";
//                break;
//            case STATE_BACK_IDLE:
//                animator.SetInteger("State", STATE_BACK_IDLE);
//                direction = "up";
//                break;
//            case STATE_LEFT_IDLE:
//                animator.SetInteger("State", STATE_LEFT_IDLE);
//                direction = "left";
//                break;
//            case STATE_RIGHT_IDLE:
//                animator.SetInteger("State", STATE_RIGHT_IDLE);
//                direction = "right";
//                break;
//
//        }
//
//        _currentAnimationState = state;
//    }

}
