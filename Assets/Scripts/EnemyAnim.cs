using UnityEngine;
using System.Collections;
using UnityEditor.Animations;
//bbusing UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAnim : MonoBehaviour {
//	[RequireComponent (typeof (Animator))]
//	Animator anim;
	NavMeshAgent Agent;

	//private Vector3 velocity, smoothDeltaPosition = Vector2.zero;
	private Vector3 A,B,D;
	private Vector3 AD, BD;

    //How many these are used will depend on the enemy
    public const int STATE_FRONT_IDLE = 0;
    public const int STATE_FRONT_MOVE = 1;
    public const int STATE_FRONT_ATTACK = 2;
    public const int STATE_FRONT_DEATH = 3;
    public const int STATE_BACK_IDLE = 4;
    public const int STATE_BACK_MOVE = 5;
    public const int STATE_BACK_ATTACK = 6;
    public const int STATE_BACK_DEATH = 7;
    public const int STATE_LEFT_IDLE = 8;
    public const int STATE_LEFT_MOVE = 9;
    public const int STATE_LEFT_ATTACK = 10;
    public const int STATE_LEFT_DEATH = 11;
    public const int STATE_RIGHT_IDLE = 12;
    public const int STATE_RIGHT_MOVE = 13;
    public const int STATE_RIGHT_ATTACK = 14;
    public const int STATE_RIGHT_DEATH = 15;

    public string direction;
    int _currentAnimationState;

    Animator anim;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update(){
		Agent = gameObject.GetComponent<NavMeshAgent>();
		D = GameObject.Find("Camera").GetComponent<Camera>().transform.position;
		B = Agent.steeringTarget;
		A = transform.position;
		AD = D - A;
		BD = D - B;
		Vector3 viewport = Vector3.Cross (AD, BD);
		if (viewport.y >0) {
            //heading right
            changeState(STATE_RIGHT_MOVE);
            direction = "right";
		} else {
            //heading left
            changeState(STATE_LEFT_MOVE);
            direction = "left";
		}
	}

    void changeState(int state)
    {
        if (_currentAnimationState == state){
            return;
        }
    }

    private string getDirection()
    {
        return direction;
    }
}
