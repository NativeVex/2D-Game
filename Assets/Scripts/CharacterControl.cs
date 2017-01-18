using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    public float walkSpeed = 1; // player left right walk speed
    public float runSpeed = 2;
    private bool _isGrounded = true; // is player on the ground?

    Animator animator;

    //some flags to check when certain animations are playing
    bool isFrontIdle = false;
    bool isWalkUp = false;
    bool isBackIdle = false;
    bool isWalkDown = false;
    bool isLeftIdle = false;
    bool isWalkLeft = false;
    bool isRightIdle = false;
    bool isWalkRight = false;

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

    // Use this for initialization
    void Start()
    {
        //define the animator attached to the player
        animator = this.GetComponent<Animator>();
    }

    // FixedUpdate is used insead of Update to better handle the physics based jump
    void FixedUpdate()
    {
        //Check for keyboard input
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            changeState(STATE_WALKLEFT);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKLEFT);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            changeState(STATE_LEFT_IDLE);
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            changeState(STATE_WALKRIGHT);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKRIGHT);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            changeState(STATE_RIGHT_IDLE);
        }

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.up * runSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKUP);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            changeState(STATE_BACK_IDLE);
        }

        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * runSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * walkSpeed * Time.deltaTime);
            changeState(STATE_WALKDOWN);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            changeState(STATE_FRONT_IDLE);
        }
    }

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {

            case STATE_WALKUP:
                animator.SetInteger("State", STATE_WALKUP);
                break;

            case STATE_WALKDOWN:
                animator.SetInteger("State", STATE_WALKDOWN);
                break;

            case STATE_WALKLEFT:
                animator.SetInteger("State", STATE_WALKLEFT);
                break;

            case STATE_WALKRIGHT:
                animator.SetInteger("State", STATE_WALKRIGHT);
                break;

            case STATE_FRONT_IDLE:
                animator.SetInteger("State", STATE_FRONT_IDLE);
                break;
            case STATE_BACK_IDLE:
                animator.SetInteger("State", STATE_BACK_IDLE);
                break;
            case STATE_LEFT_IDLE:
                animator.SetInteger("State", STATE_LEFT_IDLE);
                break;
            case STATE_RIGHT_IDLE:
                animator.SetInteger("State", STATE_RIGHT_IDLE);
                break;

        }

        _currentAnimationState = state;
    }
}
