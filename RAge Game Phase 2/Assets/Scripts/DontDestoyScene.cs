using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyScene : MonoBehaviour {

    public static DontDestoyScene instance;
            
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
;	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
