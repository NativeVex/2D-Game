using UnityEngine;
using System.Collections;

public class VisualScript : MonoBehaviour {
	public string[] tags;
	public float dmg;
	public GameObject AttackScript;
   // public string AttackObj;
    public int direction;
    public float runSpeed;

    // Use this for initialization
    void Start()
    {
        AttackScript = Instantiate(AttackScript);
        AttackScript.GetComponent<AttackScript>().dmg = dmg;
        AttackScript.GetComponent<AttackScript>().tags = tags;
        AttackScript.GetComponent<AttackScript>().Parent = gameObject;
    }

    void Update()
    {
        Move();
    
    }
    void Move()
    {
        switch (direction)
        {
            case 0:
                
                gameObject.transform.Translate(Vector3.back * runSpeed * Time.deltaTime);
                break;
            case 1:
               
                gameObject.transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                break;
            case 2:
               
                gameObject.transform.Translate(Vector3.right * runSpeed * Time.deltaTime);
                break;
            case 3:
             
                gameObject.transform.Translate(Vector3.left * runSpeed * Time.deltaTime);
                break;
        }
    }

}
