using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {
    float speed = 1f;
    Animator anim;

    public bool ATTACK = false;
    public const int DIR_FRONT = 0, DIR_BACK = 1, DIR_LEFT = 2, DIR_RIGHT = 3;
    public int direction;

    void Start () {
        ATTACK = false;
        anim = this.gameObject.GetComponent<Animator>();
	}
	
	void Update () {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
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
        if (col.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
