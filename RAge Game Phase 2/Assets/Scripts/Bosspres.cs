using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bosspres : MonoBehaviour {

    public Animator animator;
    public Transform[] spawnpoints;
        
    // Use this for initialization
    void Start () {
        animator.SetFloat("Blend", 0);
    }
	
	// Update is called once per frame
	void Update () {

        StartCoroutine(Wait());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           

            animator.SetFloat("Blend", Random.Range(1, 3));

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetFloat("Blend", 0);
        }
    }


    private void Shrink()
    {
        print("shh");
        //animator.SetBool("Shrink", true);
        //transform.position = spawnpoints[Random.Range(0, 4)].position;
        
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(20f,25f));

        Shrink();

    }
}
