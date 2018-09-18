using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvaslookat : MonoBehaviour {
    public GameObject cam;
    public GameObject target;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void LateUpdate () {
        
        transform.LookAt(target.transform);

    }
   
        
}
