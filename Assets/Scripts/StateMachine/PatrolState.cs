using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState 

{
	private readonly StatePatternEnemy enemy;
	private int nextWayPoint;

	public PatrolState (StatePatternEnemy statePatternEnemy)
	{
		enemy = statePatternEnemy;
	}

	public void UpdateState()
	{
		Look ();
		Patrol ();
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.tag.Equals("Player"))
			ToAlertState ();
        if (other.tag.Equals("Range"))
        {
            enemy.gameObject.transform.position = Vector3.MoveTowards(enemy.gameObject.transform.position, other.gameObject.transform.position, Time.deltaTime * 2);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Ranger"))
        {

        }
    }


	public void ToPatrolState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}

	public void ToChaseState()
	{
		enemy.currentState = enemy.chaseState;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag ("Player")) {
			enemy.chaseTarget = hit.transform;
			ToChaseState();
		}
		/*if (hit.collider != null) {
			Debug.Log (hit.collider.tag);
		} */
	}

	void Patrol ()
	{
		//enemy.meshRendererFlag.material.color = Color.green;
		enemy.navMeshAgent.destination = enemy.wayPoints [nextWayPoint].position;
		enemy.navMeshAgent.Resume ();

		if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending) {
			nextWayPoint =(nextWayPoint + 1) % enemy.wayPoints.Length;

		}
	}

}