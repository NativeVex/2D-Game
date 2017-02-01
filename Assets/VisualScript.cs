using UnityEngine;
using System.Collections;

public class VisualScript : MonoBehaviour {
	public string[] tags;
	public float dmg;
	public GameObject AttackScript;
	// Use this for initialization
	void Start () {
		AttackScript = Instantiate (AttackScript);
		AttackScript.GetComponent<AttackScript> ().dmg = dmg;
		AttackScript.GetComponent<AttackScript> ().tags = tags;
		AttackScript.GetComponent<AttackScript> ().Parent = gameObject;	
	}
}
