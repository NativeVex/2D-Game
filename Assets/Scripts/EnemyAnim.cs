using UnityEngine;
using System.Collections;
//bbusing UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAnim : MonoBehaviour {
	//Debug
	//public string dir;



	NavMeshAgent Agent;

	//private Vector3 velocity, smoothDeltaPosition = Vector2.zero;
	private Vector3 A,B,D;
	private Vector3 AD, BD;
    public AudioClip audio;


    //How many these are used will depend on the enemy
    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT =3, DIR_RIGHT =2;
	public bool ATTACK = false, DED = false;
    public float speed;
    Animator anim;
    public int dmg;
    private float lastDamage = 0;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }


    void Update(){
        if (gameObject.GetComponent<HP>().health <= 0)
        {
            DED = true;
            anim.SetBool("Dead", true);
            
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy") || anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy "))
        {
            Destroy(gameObject);
        }

		Agent = gameObject.GetComponent<NavMeshAgent>();
		D = GameObject.Find("Camera").GetComponent<Camera>().transform.position;
		B = Agent.steeringTarget;
		A = transform.position;
		AD = D - A;
        
		BD = D - B;
		Vector3 viewport = Vector3.Cross (AD, BD);
		if (viewport.y >0) {
			//heading right
			//dir = "right";
			anim.SetInteger("Dir",DIR_RIGHT);
		} else {

			//heading left
			//dir = "left";
			anim.SetInteger("Dir",DIR_LEFT);
		}
	}

    void FixedUpdate()
    {
        if (lastDamage >= 1)
        {
            lastDamage = 0;
        }
        lastDamage += Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
        {
            col.gameObject.GetComponent<HP>().health -= dmg;
            
            ATTACK = true;
            print("Attack = " + ATTACK);
            anim.SetBool("Attack", ATTACK);
        }
        if (col.tag.Equals("Attack"))
        {
            gameObject.GetComponent<HP>().health -= dmg;
            AudioSource audio1 = GetComponent<AudioSource>();
            audio1.Play();
            audio1.clip = audio;
            audio1.Play();
        }
     /*   if (col.tag.Equals("AttackRange"))
        {
            ATTACK = true;
            anim.SetBool("Attack", ATTACK);
        } */
        if (col.tag.Equals("Range"))
        {
            gameObject.GetComponent<StatePatternEnemy>().following = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag.Equals("Range"))
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, col.gameObject.transform.position, Time.deltaTime * speed);
        }
        if (col.tag.Equals("Player"))
        {
            if (lastDamage >= 1)
            {
                col.gameObject.GetComponent<HP>().health -= dmg;
            }
            
        }
    }

    void OnTriggerExit(Collider col)
    {
        /*  if (col.tag.Equals("AttackRange"))
          {
              ATTACK = false;
              anim.SetBool("Attack", ATTACK);
          } */
       if (col.tag.Equals("Player"))
        {
            ATTACK = false;
            print("Attack = " + ATTACK);
            anim.SetBool("Attack", ATTACK);
        }
        if (col.tag.Equals("Range"))
        {
            gameObject.GetComponent<StatePatternEnemy>().following = false;
        }
    }
}
