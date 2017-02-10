using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerRandGen : MonoBehaviour {

    public GameObject[] plants;
    public GameObject[] trees;
    public float Xmin;
    public float Xmax;
    public float Zmin;
    public float Zmax;
    public int amount;
    public int treeAmount;
    public ArrayList treeLocations = new ArrayList(); 
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            int randObj = (int)(Random.Range(0, plants.Length));
            GameObject obj = plants[randObj];
            Instantiate(obj, new Vector3(Random.Range(Xmin, Xmax), 0, Random.Range(Zmin, Zmax)), Quaternion.Euler(0, 0, 0));
        }
        for (int i = 0; i < treeAmount; i++)
        {
            int randObj = (int)(Random.Range(0, trees.Length));
            GameObject obj = trees[randObj];
            Vector3 location = new Vector3 (Random.Range(Xmin, Xmax), 0, Random.Range(Zmin, Zmax));
            bool alreadyUsed = false;
            while (alreadyUsed)
            {
                for (int k = 0; k < treeLocations.Count; k++)
                {
                    Vector3 compare = (Vector3)treeLocations[k];
                    if (location.x == compare.x && location.y == compare.y & location.z == compare.z)
                    {
                        alreadyUsed = true;
                        return;
                    }
                }
            }
            treeLocations.Add(location);
            Instantiate(obj, location, obj.transform.rotation);
        }
    }
}
