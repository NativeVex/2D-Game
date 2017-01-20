using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public Vector3 direction;
    public float speed = 1f;
	public string[] tags;

    Animator anim;

    public bool ATTACK = false;
    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT = 2, DIR_RIGHT = 3;
    public int direction;

    void Start () {
		Parent = this.gameObject.transform.parent.gameObject;
		anim = Parent.gameObject.GetComponent<Animator>();
		Parent.transform.position = direction;
	}
	
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(""))//change to foreach tags
        {
            Destroy(gameObject);
        }
        else
        {
            anim.SetInteger("Dir", direction);
            if (direction == DIR_FRONT)
            {
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (direction == DIR_BACK)
            {
                gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            else if (direction == DIR_LEFT)
            {
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (direction == DIR_RIGHT)
            {
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
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
    }
}
