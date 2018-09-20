using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
   public Camera cam;
    internal static Camera main;

    // Use this for initialization
    void Start () {
       // cam = Camera.main;

    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
