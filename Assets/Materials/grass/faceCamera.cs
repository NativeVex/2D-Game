using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour {
	//public GameObject cam;

	// Update is called once per frame
	void Update () {
		Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
		this.gameObject.transform.LookAt (cam.gameObject.transform);
	}
}
