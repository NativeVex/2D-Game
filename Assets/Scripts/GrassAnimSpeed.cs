using UnityEngine;
using System.Collections;

public class GrassAnimSpeed : MonoBehaviour {
	//public Animation anim;
	public float speed;

	// Use this for initialization
	void Start () {
		Animation temp = (Animation)this.GetComponent ("Animation");
		temp ["grass"].speed = Random.value * this.speed;

		//<Animation>().Play("grass").speed = this.speed*Random.value;
		//anim ["grass"].speed = this.speed*Random.value;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
