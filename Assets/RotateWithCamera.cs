using UnityEngine;
using System.Collections;

public class RotateWithCamera : MonoBehaviour {
	Camera reference;
	void Start(){
		reference = (Camera)this.gameObject.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		
	
	}
}
