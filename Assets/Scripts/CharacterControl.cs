using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    public GameObject Attack; 
    Animator animator;
    Animator attackAnim;

    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT = 2, DIR_RIGHT = 3;
    public bool ATTACK = false, DEAD = false, WALK = false;

    int _currentAnimationState = DIR_FRONT;
    bool _currentWalk = false;

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
        attackAnim = Attack.GetComponent<Animator>();
        //Attack = (GameObject)Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
        animator.SetInteger("Dir", DIR_BACK);
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update()
    {
        //Check for keyboard input
        //Attack.transform.position = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject AttackClone = Attack;
            ATTACK = true;
            animator.SetBool("Attack", ATTACK);
            AttackClone = (GameObject)Instantiate(Attack, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
            ATTACK = AttackClone.gameObject.GetComponent<AttackScript>().ATTACK;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Left
        {
            print("run left");
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_LEFT, WALK);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))   //Walk Left
        {
            print("walk left");
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_LEFT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))  //Left Idle
        {
            print("idle left");
            WALK = false;
            changeState(DIR_LEFT, WALK);
        }

    /*    if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Right
        {
            print("run right");
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_RIGHT, WALK);
        }
        else if (Input.GetKey(KeyCode.RightArrow))  //Walk Right
        {
            print("walk right");
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_RIGHT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //Right Idle
        {
            print("idle right");
            WALK = false;
            changeState(DIR_RIGHT, WALK);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
        {
            print("run up");
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_BACK, WALK);
        }
        else if (Input.GetKey(KeyCode.UpArrow))  //Walk Up
        {
            print("walk up");
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_BACK, WALK);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) //Up Idle
        {
            print("idle up");
            WALK = false;
            changeState(DIR_BACK, WALK);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
        {
            print("run down");
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT, WALK);
        }
        else if (Input.GetKey(KeyCode.DownArrow))  //Walk Down
        {
            print("walk down");
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) //Right Idle
        {
            print("idle down");
            WALK = false;
            changeState(DIR_FRONT, WALK);
        } */
    }

    void changeState(int state, bool walk)
    {
        if (state != _currentAnimationState)
        {
            animator.SetInteger("Dir", state);
        }
        if (walk != _currentWalk)
        {
            animator.SetBool("Walk", walk);
        }
    }
}
