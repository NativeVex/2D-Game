using UnityEngine;
using System.Collections;
using System;

public struct GenTerrain {
	private int dim;
	private static Sprite[] prefabs;
	Sprite[][] Sto {
		get {
			return new Sprite[dim][dim];
		}
	}
	// Use this for initialization
	GenTerrain (int dim) {
		this.dim = dim;
		//gen terrain here
	
	}

	void addTo(){
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
