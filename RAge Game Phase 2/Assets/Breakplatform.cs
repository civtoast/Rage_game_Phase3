using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakplatform : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
        //anim.SetBool("Destroy", false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
           // anim.SetBool("Destroy", true);
            Destroy(this.gameObject);
        }
    }
}
