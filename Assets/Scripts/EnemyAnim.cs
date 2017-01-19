using UnityEngine;
using System.Collections;
[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAnim : MonoBehaviour {
	const int STATE_WALKUP = 1, STATE_WALKDOWN =0, STATE_WALKLEFT = 2, STATE_WALKRIGHT = 3;
	private Vector3 A,B,D;
	private Vector3 AD, BD;
	NavMeshAgent Agent;


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
		} else {
			//heading left
		}

	}
}
