using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
   // public GameObject Attack;
    Animator animator;
    Animator attackAnim;

    public bool ATTACK = false;
    public int DIR = 0;
    public bool MOVE = false;
    public bool DEAD = false;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
     //   attackAnim = Attack.GetComponent<Animator>();
     //   Attack = (GameObject)Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
        //Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Left
        {
            MOVE = true;
            DIR = 2;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))   //Walk Left
        {
            MOVE = true;
            DIR = 2;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))  //Left Idle
        {
            MOVE = false;
            DIR = 2;
            changeState(MOVE, ATTACK, DEAD, DIR);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Right
        {
            MOVE = true;
            DIR = 3;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))  //Walk Right
        {
            MOVE = true;
            DIR = 3;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //Right Idle
        {
            MOVE = false;
            DIR = 3;
            changeState(MOVE, ATTACK, DEAD, DIR);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
        {
            MOVE = true;
            DIR = 1;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))   //Walk Up
        {
            MOVE = true;
            DIR = 1;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))  //Up Idle
        {
            MOVE = false;
            DIR = 1;
            changeState(MOVE, ATTACK, DEAD, DIR);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
        {
            MOVE = true;
            DIR = 0;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))  //Walk Down
        {
            MOVE = true;
            DIR = 0;
            changeState(MOVE, ATTACK, DEAD, DIR);
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))  //Down Idle
        {
            MOVE = false;
            DIR = 0;
            changeState(MOVE, ATTACK, DEAD, DIR);
        }
    }

    void changeState(bool MOVE, bool ATTACK, bool DEAD, int DIR)
    {
        animator.SetInteger("Dir", DIR);
        animator.SetBool("Walk", MOVE);
        animator.SetBool("Dead", DEAD);
        animator.SetBool("Attack", ATTACK);
    }
}
