using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
	
	//this is a simple script that will rotate the transform of an object towards the camera
	//its an easy way to create the effect of billboards always oriented towards the camera.
	//We use it to have the enemies health bar always face the player.
	
	public Camera cam;

	private void Start () {
		
	}

	public void LateUpdate () {
		transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
	}
}
