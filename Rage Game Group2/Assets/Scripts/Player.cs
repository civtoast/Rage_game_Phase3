using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public Animator animator;
    //public float jumpspeed = 0.5f;

    public AnimationCurve curve;

    float jumpTime = 0;

    bool isJumping = false;
       
    void Start()
    {


    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


       Vector3 movement = new Vector3(0f, 0f, vertical);
       Vector3 rotation = new Vector3(0f, horizontal, 0f);

        transform.Translate(movement * Time.deltaTime * moveSpeed);
       transform.Rotate(rotation * Time.deltaTime * rotationSpeed);
        animator.SetFloat("Forward", vertical);
        animator.SetFloat("Turn", horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                isJumping = true;
                jumpTime = 0;
                animator.SetBool("Jumptrue", true);
               
            } 
            
        }

        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            animator.SetFloat("Jump", Mathf.Lerp(-9, 5, curve.Evaluate(Mathf.Lerp(0, 1, jumpTime))));

           // print(curve.Evaluate(Mathf.Lerp(0, 1, jumpTime)));
        }






    }
    private void OnCollisionEnter(Collision collision)
    {

        animator.SetBool("Jumptrue", false);
        animator.SetBool("OnGround", true);
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("OnGround", false);
    }
}

   
