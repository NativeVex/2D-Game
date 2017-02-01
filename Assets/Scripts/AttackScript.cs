using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public string[] tags;
	public float dmg;
	public GameObject Parent;
	void Update () {
		if (Parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Destroy")) {
			Destroy (Parent);
			Destroy (gameObject);
		}
	}
    void OnCollisionEnter(Collider col)
    {
		foreach(string temp in tags){
			if (col.gameObject.tag.Equals(temp))
	        {
				col.gameObject.GetComponent<HP> ().health-=dmg;
				Destroy(Parent);
	        }
		}
    }
}
