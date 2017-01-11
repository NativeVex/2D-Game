using UnityEngine;
using System.Collections;
//using System;

public class GenGrass : MonoBehaviour {
	public GameObject[] prefabs;
	public int dim;
	private GameObject[,] Sto;
	public float scale;
	public int grassSpeedLimit;

	// Use this for initialization
	void Start () {
		Sto = new GameObject[dim,dim];
		for (int x = 0; x < dim; x++) {
			for (int z = 0; z < dim; z++) {
				Sto [x, z] = (GameObject)Instantiate (prefabs [0], new Vector3 (x * scale*Random.value, 0, z * scale*Random.value), Quaternion.identity);
				Sto [x, z].GetComponent<Animator> ().SetFloat ("speedMultiplier", Random.value*grassSpeedLimit); 
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
