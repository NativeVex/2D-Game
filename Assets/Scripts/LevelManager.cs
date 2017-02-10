using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    private int monstersLeft;
    public float scale;
    public int startAmount;
    public GameObject[] Monsters;
    public GameObject Player;
    public ArrayList monsterLocations = new ArrayList();
    public float Xmin;
    public float Xmax;
    public float Zmin;
    public float Zmax;
    public float y;
    public float angle;
    public int level;
    public float speed;
    public float TimeLeft;
    public Text HPLeft;
    public Text time;
    public int enemyDmg;
    public int enemyHealth;
    public float setSpeed;
    public Text EnemiesLeft;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < startAmount; i++)
        {
            int randObj = (int)(Random.Range(0, Monsters.Length));
            GameObject obj = Monsters[randObj];
            Vector3 location = new Vector3(Random.Range(Xmin, Xmax), y, Random.Range(Zmin, Zmax));
            bool alreadyUsed = false;
            while (alreadyUsed)
            {
                for (int k = 0; k < monsterLocations.Count; k++)
                {
                    Vector3 compare = (Vector3)monsterLocations[k];
                    if (location.x == compare.x && location.y == compare.y & location.z == compare.z)
                    {
                        alreadyUsed = true;
                        return;
                    }
                }
            }
            monsterLocations.Add(location);
            obj.transform.localScale = new Vector3(scale, scale, scale);
            obj.GetComponent<EnemyAnim>().speed = speed;
            obj.GetComponent<EnemyAnim>().dmg = enemyDmg;
            obj.GetComponent<HP>().health = enemyHealth;
            obj.GetComponent<StatePatternEnemy>().Xmin = Xmin;
            obj.GetComponent<StatePatternEnemy>().Xmax = Xmax;
            obj.GetComponent<StatePatternEnemy>().Zmin = Zmin;
            obj.GetComponent<StatePatternEnemy>().Zmax = Zmax;
            obj.GetComponent<NavMeshAgent>().speed = setSpeed;
            Instantiate(obj, location, Quaternion.Euler(angle, 0, 0));
            obj.gameObject.name = Monsters[randObj].name;
        }
    }
	
	// Update is called once per frame
	void Update () {
        HPLeft.text = "HP: " + Player.GetComponent<HP>().health;
        TimeLeft -= Time.deltaTime;
        time.text = "Time Left: " + (int)TimeLeft;
        EnemiesLeft.text = "Enemies Left: " + monstersLeft;
        if (Player.GetComponent<HP>().health <= 0 || TimeLeft <= 0)
        {
            Destroy(Player);
            SceneManager.LoadScene("Start Screen");
        }
        EnemyCount();
       // print (monstersLeft);
        if (monstersLeft == 0)
        {
            string nextLevel = "level " + (level + 1);
            if (level == 5)
            {
                SceneManager.LoadScene("Start Screen");
            }
            else
            {
                SceneManager.LoadScene(nextLevel);
            }
            
        }
	}

    void EnemyCount()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        monstersLeft = gos.Length;
    }
}
