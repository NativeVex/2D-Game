using UnityEngine;
using System.Collections;

public class AttackBundle : MonoBehaviour
{

	public AttackBundle(string[] tags, int dmg, int dir, float speed,GameObject Prefab, GameObject parent,int scale){
		Prefab = (GameObject)Instantiate (Prefab,parent.transform.position,Quaternion.identity);
		Prefab.GetComponent<VisualScript> ().runSpeed = speed;
		Prefab.GetComponent<VisualScript> ().direction = dir;
		Prefab.GetComponent<VisualScript> ().dmg = dmg;
		Prefab.GetComponent<VisualScript> ().tags = tags;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

