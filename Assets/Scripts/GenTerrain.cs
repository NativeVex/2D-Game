using UnityEngine;
using System.Collections;
using System;

public class GenTerrain: MonoBehaviour {
	public GameObject[] prefabs;
	public GameObject[,] Sto;
	public int dim;
	public int scale;
	// Use this for initialization
	void Start() {
		//gen default terrain here
		for (int x = 0; x < dim; x++) {
			for (int y = 0; y < dim; y++) {
				Sto [x, y] = (GameObject)Instantiate(prefabs[0].gameObject
					,prefabs[0].gameObject.transform.position//new Vector3(x*scale,y*scale,0)
					,prefabs[0].gameObject.transform.rotation);//Quaternion.identity);
			}
		}
	}
		

	void addTo(){
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
