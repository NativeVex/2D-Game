using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class StatePatternEnemy : MonoBehaviour
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
    public float walkSpeed = 1.0f;
	public Transform[] wayPoints;
    public Transform wayPoint;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	//public MeshRenderer meshRendererFlag;
	public float attackDistance;
	public GameObject Attack;
    public bool following = false;
    public GameObject Player;
    public float Xmin, Xmax, Zmin, Zmax;
    public int nextWayPoint;

    [HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public NavMeshAgent navMeshAgent;


	private void Awake()
	{
		chaseState = new ChaseState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);
        
		navMeshAgent = GetComponent<NavMeshAgent> ();
		if (wayPoints.Length <= 0) {
			popWaypoints (0);
		} else {
			for (int i = 0; i < wayPoints.Length; i++) {
				if (wayPoints [i] == null) {
					popWaypoints (wayPoints.Length);
				}
			}
		}

	}

	void popWaypoints(int number){//TODO
		if (number == 0) {
			number = 5;
		}
		//do stuff here
		wayPoints = new Transform[number];
		for (int i = 0; i < number; i++) {
			//kill me!
			//Later.
			//wayPoints [i] = new GameObject ();
		}
		//navMeshAgent.hasPath;
//		NavMesh.CalculatePath (gameObject.transform.position,new Vector3(Random.value*lim,Random.value*lim),);
	}

	// Use this for initialization
	void Start () 
	{
        Player = GameObject.Find("playerTrolley");

        if (following == false)
        {
            for (int i = 0; i < wayPoints.Length; i++)
            {
                Vector3 random = new Vector3(Random.Range(Xmin, Xmax), gameObject.transform.position.y, Random.Range(Zmin, Zmax));
                for (int y = 0; y < i; y++)
                {
                    if (y == i)
                    {
                        return;
                    }
                    while (wayPoints[y].position.x == random.x && wayPoints[y].position.z == random.z)
                    {
                        random = new Vector3(Random.Range(Xmin, Xmax), gameObject.transform.position.y, Random.Range(Zmin, Zmax));
                    }
                }
                Transform newWayPoint = wayPoint;
                newWayPoint.position = random;
                wayPoints[i] = newWayPoint;
                wayPoints[i] = (Transform)Instantiate(newWayPoint, random, Quaternion.Euler(0, 0, 0));
            }
         //   currentState = patrolState;
        }

    }

   /* void FixedUpdate()
    {
        if (following == true)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.gameObject.transform.position, Time.deltaTime * 0.1f);
        }
    } */
	// Update is called once per frame
	void Update () 
	{
        if (following == true)
        {
            this.navMeshAgent.Stop();
        }
        else
        {
            Patrol();
        }
	}

    void Patrol()
    {
        //enemy.meshRendererFlag.material.color = Color.green;
        this.navMeshAgent.destination = this.wayPoints[nextWayPoint].position;
        this.navMeshAgent.Resume();

        if (this.navMeshAgent.remainingDistance <= this.navMeshAgent.stoppingDistance && !this.navMeshAgent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % this.wayPoints.Length;
        }
    }

  /*  private void OnTriggerEnter(Collider other)
	{
        if (other.tag.Equals("Player"))
        {
          //  currentState.OnTriggerEnter (other);
        }
    } */
}