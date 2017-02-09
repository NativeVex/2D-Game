using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
    public float walkSpeed = 1.0f;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0,.5f,0);
	public MeshRenderer meshRendererFlag;

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
		currentState = patrolState;
	}

	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}