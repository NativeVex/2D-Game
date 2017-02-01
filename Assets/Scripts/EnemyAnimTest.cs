using UnityEngine;
using System.Collections;

public class EnemyAnimTest : MonoBehaviour {
    public bool ATTACK = false;
    public bool MOVE = false;
    public bool DEAD = false;
    public int DIR = 0;

    bool inRange = false;
    Animator animator;
    public GameObject Player;
    int hitCount = 0;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        followPlayer();
        if (ATTACK)
        {
            animator.SetBool("Attack", ATTACK);
        }
        if (hitCount == 3)
        {
            DEAD = true;
            animator.SetBool("Dead", DEAD);
        }
    }

    void followPlayer()
    {
       // if (inRange)
      //  {
            MOVE = true;
            animator.SetBool("Move", MOVE);
            gameObject.transform.Translate(Player.transform.position);
         //   GetDir(transform.position, Player.transform.position);
      /*  }
        else
        {
            int rand = Random.Range(0, 1);
            if (rand == 1)
            {
                MOVE = false;
                animator.SetBool("Move", MOVE);
            }
            else
            {
                MOVE = true;
                animator.SetBool("Move", MOVE);
                float xValue = gameObject.transform.position.x;
                float zValue = gameObject.transform.position.z;
                Vector3 random = new Vector3(Random.Range(xValue - 10f, xValue + 10f), transform.position.y, Random.Range(zValue - 10f, zValue + 10f));
                gameObject.transform.position = Vector3.MoveTowards(transform.position, random, 10 * Time.deltaTime);
                GetDir(transform.position, random);
            }
        }*/
    }

    void GetDir(Vector3 pos, Vector3 tar)
    {
        float dot = Vector3.Dot(pos, tar);
        dot = dot / (pos.magnitude * tar.magnitude);
        var acos = Mathf.Acos(dot);
        var angle = acos * 180 / Mathf.PI;
        if (angle > 180)
        {
            DIR = 0; //left
            animator.SetInteger("State", DIR);
        }
        else
        {
            DIR = 1; //right
            animator.SetInteger("State", DIR);
        }
    }

    void OnCollisionEnter(Collider col)
    {
        if (col.tag.Equals("Range"))
        {
            inRange = true;
        }
        if (col.tag.Equals("AttackRange"))
        {
            ATTACK = true;
        }
        if (col.tag.Equals("Attack"))
        {
            hitCount++;
        }
    }

    void OnCollisionExit(Collider col)
    {
        if (col.tag.Equals("Range"))
        {
            inRange = false;
        }
        if (col.tag.Equals("AttackRange"))
        {
            ATTACK = false;
        }
    }
}
