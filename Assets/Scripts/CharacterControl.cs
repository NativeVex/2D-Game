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

<<<<<<< HEAD
    int _currentAnimationState = DIR_FRONT;
    bool _currentWalk = false;
||||||| merged common ancestors
    //animation states - the values in the animator conditions
    const int STATE_FRONT_IDLE = 0;
    const int STATE_BACK_IDLE = 2;
    const int STATE_LEFT_IDLE = 4;
    const int STATE_RIGHT_IDLE = 6;
    const int STATE_WALKDOWN = 1;
    const int STATE_WALKUP = 3;
    const int STATE_WALKLEFT = 5;
    const int STATE_WALKRIGHT = 7;

    int _currentAnimationState = STATE_FRONT_IDLE;
    string direction = "front";
=======
    //animation states - the values in the animator conditions
    const int STATE_FRONT_IDLE = 0;
    const int STATE_BACK_IDLE = 2;
    const int STATE_LEFT_IDLE = 4;
    const int STATE_RIGHT_IDLE = 6;
    const int STATE_WALKDOWN = 1;
    const int STATE_WALKUP = 3;
    const int STATE_WALKLEFT = 5;
    const int STATE_WALKRIGHT = 7;

    const int STATE_ATTACK_IDLE = 8;
    const int STATE_ATTACK = 9;

    int _currentAnimationState = STATE_FRONT_IDLE;
    int _currentAttack = STATE_ATTACK_IDLE;
    string direction = "front";
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
        attackAnim = Attack.GetComponent<Animator>();
        //Attack = (GameObject)Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void Update()
    {
        //Check for keyboard input
        //Attack.transform.position = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
<<<<<<< HEAD
            GameObject AttackClone = Attack;
            ATTACK = true;
            AttackClone.gameObject.GetComponent<AttackScript>().direction = _currentAnimationState;
            animator.SetBool("Attack", ATTACK);
            AttackClone = (GameObject)Instantiate(Attack, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
            ATTACK = AttackClone.gameObject.GetComponent<AttackScript>().ATTACK;
||||||| merged common ancestors
            GameObject AttackClone = Attack;
            AttackClone.gameObject.GetComponent<AttackScript>().direction = direction;
            AttackClone = (GameObject)Instantiate(Attack, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.Euler(0, 0, 0));
=======
            if (direction.Equals("up"))
            {
                //TODO make this appear directly above the player. I think it does this already
                //Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                Attack.transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
            }
            else if (direction.Equals("down"))
            {
                //TODO make this appear below the player. Definately doesn't do this already
                //Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                Attack.transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
            }
            else if (direction.Equals("left"))
            {
                //TODO make this appear left
                //Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                Attack.transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            }
            else if (direction.Equals("right"))
            {
                //TODO i'm sure you can figure this one out.
                //Instantiate(Attack, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.Euler(0, 0, 0));
                Attack.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            }
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
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
        else if (Input.GetKey(KeyCode.RightArrow))  //Walk Right
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_RIGHT, WALK);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) //Right Idle
        {
            WALK = false;
            changeState(DIR_RIGHT, WALK);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Up
        {
<<<<<<< HEAD
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_BACK, WALK);
||||||| merged common ancestors
            transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
=======
            transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
        }
        else if (Input.GetKey(KeyCode.UpArrow))   //Walk Up
        {
<<<<<<< HEAD
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_BACK, WALK);
||||||| merged common ancestors
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
=======
            transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))  //Up Idle
        {
            WALK = false;
            changeState(DIR_BACK, WALK);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) //Run Down
        {
<<<<<<< HEAD
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT, WALK);
||||||| merged common ancestors
            transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
=======
            transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
        }
        else if (Input.GetKey(KeyCode.DownArrow))  //Walk Down
        {
<<<<<<< HEAD
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            WALK = true;
            changeState(DIR_FRONT,WALK);
||||||| merged common ancestors
            transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
=======
            transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))  //Down Idle
        {
            WALK = false; 
            changeState(DIR_FRONT, WALK);
        }
    }

<<<<<<< HEAD
    void changeState(int state, bool walk)
||||||| merged common ancestors
    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
=======
  /*  bool AnimatorIsPlaying(string stateName)
    {
        return attackAnim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    } */

   /* void PlayerAttack(int state)
    {
        if (_currentAnimationState == state)
            return;
        switch (state)
        {

            case STATE_ATTACK_IDLE:
                animator.SetInteger("State", STATE_ATTACK_IDLE);
                break;

            case STATE_ATTACK:
                animator.SetInteger("State", STATE_ATTACK);
                break;
        }
    } */

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
>>>>>>> e42dc4986c078452a050bbba920a8f24b499c9e6
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
