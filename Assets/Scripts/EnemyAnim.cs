using UnityEngine;
using System.Collections;
[RequireComponent (typeof (NavMeshAgent))]

public class EnemyAnim : MonoBehaviour {
//	[RequireComponent (typeof (Animator))]
//	Animator anim;
	NavMeshAgent agent;

	//private Vector3 velocity, smoothDeltaPosition = Vector2.zero;
	private Vector3 A,B,D;
	private Vector3 AD, BD;
	void Update(){
		agent = gameObject.GetComponent<NavMeshAgent>();
		D = GameObject.Find("Camera").GetComponent<Camera>().transform.position;
		B = agent.steeringTarget;
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
