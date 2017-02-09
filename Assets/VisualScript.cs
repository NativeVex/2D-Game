using UnityEngine;
using System.Collections;

public class VisualScript : MonoBehaviour {
	public string[] tags;
	public float dmg;
	public GameObject AttackScript;
    public string AttackObj;
   // public GameObject Player;

	// Use this for initialization
	void Start () {
		AttackScript = Instantiate (AttackScript);
        //  Player = Instantiate(Player);
        AttackScript.GetComponent<AttackScript>().AttackObject = AttackObj;
		AttackScript.GetComponent<AttackScript> ().dmg = dmg;
		AttackScript.GetComponent<AttackScript> ().tags = tags;
		AttackScript.GetComponent<AttackScript> ().Parent = gameObject;
	}

}
