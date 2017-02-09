using UnityEngine;
using System.Collections;

public class faceCamera : MonoBehaviour {
	//public GameObject cam;

	// Update is called once per frame
	void Update () {
		Camera cam = GameObject.Find("Camera").GetComponent<Camera>();
        Vector3 targetPosition = new Vector3(gameObject.transform.position.x, cam.gameObject.transform.position.y, cam.gameObject.transform.position.z);
		this.gameObject.transform.LookAt (targetPosition);
	}
}
