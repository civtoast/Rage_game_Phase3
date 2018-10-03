using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Spawnstate
{
    wave1 ,
    wave2 ,
    wave3 ,
    stop
}

public class Spawnmanager : MonoBehaviour {
    private Spawnstate spawnstate = Spawnstate.wave1;
    public GameObject[] spawnObject;
    public Transform [] spawnPosition;
    public Enemycontoller enemy;
    public float Timer = 1;
    public static List<Enemy> enemywave = new List<Enemy>();
    // Use this for initialization
    void Start () {
     
        
         
    }
	
	// Update is called once per frame
	void Update () {

        
        if (enemywave.Count == 0)
        {
            StartCoroutine(Spawmwave(3));
        }
       


    }
    IEnumerator Spawmwave(int enemycounter)
    {
        for (int i =0; i < enemycounter; i++)
        {
            GameObject obj = Instantiate(spawnObject[Random.Range(0, 3)], spawnPosition[Random.Range(0, 4)].position, spawnObject[Random.Range(0, 3)].transform.rotation);
            enemywave.Add(obj.GetComponent<Enemy>());
            yield return new WaitForSecondsRealtime(Random.Range(1f, 4f));

        }
    }
}
