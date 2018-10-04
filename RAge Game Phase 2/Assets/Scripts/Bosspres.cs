using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bosspres : MonoBehaviour
{

    public Animator animator;
    public Transform[] spawnpoints;
    public int tries = 0;
    public int maxhealth = 100;
    int currentHealth;
    public Playercontroller player;
    // Use this for initialization
    void Start()
    {
        animator.SetFloat("Blend", 0);
        StartCoroutine(Wait());
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            animator.SetBool("Death",true);
        }
        //StartCoroutine(Wait());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetFloat("Blend", Random.Range(1, 3));
            player.TakeDamage(30);
        }
        if (other.CompareTag("Shot"))
        {
            Gethit();
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
        animator.SetBool("Shrink", true);

        //transform.position = spawnpoints[Random.Range(0, 4)].position;

    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(5f, 8f));

        Shrink();

    }
    public void Grow()
    {
        if (animator.GetBool("Shrink") == true)
        {
            transform.parent = spawnpoints[Random.Range(0,spawnpoints.Length )];
            transform.localScale = Vector3.one;
            transform.localPosition = Vector3.zero;
            animator.SetBool("Shrink", false);
            animator.SetBool("Grow", true);
            StartCoroutine(Wait());
        }

    }

    


    public void Gethit()
    {
        currentHealth -= Random.Range(10,20);
    }
    
}
