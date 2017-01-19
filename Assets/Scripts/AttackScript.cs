using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
    public string direction;
    float speed = 1f;
    Animator anim;

    public const int STATE_FRONT_ATTACK = 2;
    public const int STATE_BACK_ATTACK = 6;
    public const int STATE_LEFT_ATTACK = 10;
    public const int STATE_RIGHT_ATTACK = 14;

    void Start () {
        anim = this.gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        {
            Destroy(gameObject);
        }
        else
        {
            if (gameObject.tag.Equals("Player"))
            {
                if (direction.Equals("up"))
                {
                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else if (direction.Equals("down"))
                {
                    gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
                }
                else if (direction.Equals("left"))
                {
                    gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if (direction.Equals("right"))
                {
                    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
            }
            else if (gameObject.tag.Equals("Enemy"))
            {
                if (direction.Equals("up"))
                {
                    
                    gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                else if (direction.Equals("down"))
                {
                    gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);
                }
                else if (direction.Equals("left"))
                {
                    gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else if (direction.Equals("right"))
                {
                    gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
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
