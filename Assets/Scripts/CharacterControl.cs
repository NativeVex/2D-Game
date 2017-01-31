using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    Animator animator;

    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT = 2, DIR_RIGHT = 3;
    public bool ATTACK = false, DEAD = false, WALK = false;

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update()
    {
        //Check for keyboard input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject AttackClone = (GameObject)Instantiate(this.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
            //AttackClone.GetComponent<Animator>().SetBool("Attack", true);
            print("attack");
        } 

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Left
        {
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_LEFT, WALK);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))   //Walk Left
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_LEFT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))  //Left Idle
        {
            WALK = false;
            changeState(DIR_LEFT, WALK);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Right
        {
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_RIGHT, WALK);
        }
        else if (Input.GetKey(KeyCode.RightArrow))   //Walk Right
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_RIGHT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))  //Right Idle
        {
            WALK = false;
            changeState(DIR_RIGHT, WALK);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
        {
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            WALK = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))   //Walk Up
        {
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_BACK, WALK);
            print(WALK);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))  //Up Idle
        {
            WALK = false;
            changeState(DIR_BACK, WALK);
            print(WALK);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
        {
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT, WALK);
        }
        else if (Input.GetKey(KeyCode.DownArrow))   //Walk Down
        {
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT, WALK);
            print(WALK);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))  //Down Idle
        {
            WALK = false;
            changeState(DIR_FRONT, WALK);
            print(WALK);
        }
    }

    void changeState(int state, bool walk)
    {
        animator.SetInteger("Dir", state);
        animator.SetBool("Walk", walk);
    }
}
