using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemycontoller : MonoBehaviour {
    public int enemycount;
    private int enemiesscore;
    public bool shouldspawn = true;
    public int times = 0;
    public Text score;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (enemycount == 10 )
        {
            shouldspawn = false;
            times += 1;
            
        }
        if (enemycount == 0)
        {
            shouldspawn = true;
        }
        if (enemycount<enemiesscore)
        {
            score.text = "score" + 1;
            enemiesscore = enemycount;
        }
	}
}
