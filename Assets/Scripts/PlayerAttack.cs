using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    Animator attackAnim;
    // Use this for initialization
    void Start () {
        attackAnim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack.transform.position = gameObject.transform.position;
            attackAnim.SetBool("Attack", true);
            if (DIR == 1)
            {
                Attack.transform.Translate(Vector3.back * 50 * Time.deltaTime);
            }
            else if (DIR == 0)
            {
                Attack.transform.Translate(Vector3.forward * 50 * Time.deltaTime);
            }
            else if (DIR == 2)
            {
                Attack.transform.Translate(Vector3.left * 50 * Time.deltaTime);
            }
            else if (DIR == 3)
            {
                Attack.transform.Translate(Vector3.right * 50 * Time.deltaTime);
            }
        }
    }
}
