using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
	public string[] tags;
	public float dmg;
	public GameObject Parent;
    private float speed;
    private int direction;
    public string AttackObject;
  //  public int dir;

    void Start()
    {
        speed = GameObject.Find(AttackObject).GetComponent<CharacterControl>().runSpeed;
        direction = GameObject.Find(AttackObject).GetComponent<CharacterControl>().dir;
    }
	void Update () {
		if (Parent.GetComponent<Animator>().GetCurrentAnimatorStateInfo (0).IsName ("Destroy")) {
			Destroy (Parent);
			Destroy (gameObject);
		}
        else
        {
            Move();
        }
	}

    void Move()
    {
        switch (direction)
        {
            case 0:
                Parent.gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 1:
                Parent.gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;
            case 2:
                Parent.gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            case 3:
                Parent.gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
        }
    }

	void OnCollisionEnter(Collider col)	{
		foreach(string temp in tags){
			if (col.gameObject.tag.Equals(temp))
	        {
				col.gameObject.GetComponent<HP> ().health-=dmg;
				Destroy(Parent);
	        }
		}
	} 
}

