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
//        else
//        {
//            if (gameObject.tag.Equals("Player"))
//            {
//                if (direction.Equals("up"))
//                {
//                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("down"))
//                {
//                    gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("left"))
//                {
//                    gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("right"))
//                {
//                    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
//                }
//            }
//            else if (gameObject.tag.Equals("Enemy"))
//            {
//                if (direction.Equals("up"))
//                {
//                    
//                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("down"))
//                {
//                    gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("left"))
//                {
//                    gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
//                }
//                else if (direction.Equals("right"))
//                {
//                    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
//                }
//            }
//        }
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
