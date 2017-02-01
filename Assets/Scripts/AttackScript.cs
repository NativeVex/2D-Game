using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public Vector3 direction;
	public float speed = 1f;
	public string[] tags;

	Animator anim;
	GameObject Parent;

	void Start () {
		Parent = this.gameObject.transform.parent.gameObject;
		anim = Parent.gameObject.GetComponent<Animator>();
		Parent.transform.position = direction;
	}

	void Update () {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
		{
			Destroy(gameObject.transform.parent.gameObject);
		}
	}

	void OnCollisionEnter(Collider col)
	{
		foreach(string temp in tags){
			if (col.gameObject.tag.Equals(temp))
			{
				Destroy(gameObject);
			}
		}
	}
}

    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

	void OnCollisionEnter(Collider col)
	{
		foreach(string temp in tags){
			if (col.gameObject.tag.Equals(temp))
			{
				Destroy(gameObject);
			}
		}
	} */
}

