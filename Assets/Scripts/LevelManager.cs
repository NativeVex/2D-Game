﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private int monstersLeft;
    public float scale;
    public int startAmount;
    public GameObject[] Monsters;
    public ArrayList monsterLocations = new ArrayList();
    public float Xmin;
    public float Xmax;
    public float Zmin;
    public float Zmax;
    public float y;
    public float angle;
    public int level;

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
            Instantiate(obj, location, Quaternion.Euler(angle, 0, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {
        EnemyCount();
        print (monstersLeft);
        if (monstersLeft == 0)
        {
            string nextLevel = "level " + (level + 1);
            SceneManager.LoadScene(nextLevel);
        }
	}

    void EnemyCount()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        monstersLeft = gos.Length;
    }
}
