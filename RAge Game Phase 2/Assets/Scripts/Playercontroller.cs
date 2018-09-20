using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour {
    public float walkspeed = 2;
    public float runspeed = 6;
    public float turnsmoothtime = 0.2f;
    public float jumpheight = 1;
    float turnsmoothvelocity;
    public float speedsmoothtime = 0.1f;
    float speedsmoothvelocity;
    float currentSpeed;
    Animator animator;
    public float gravity=-12;
    public Transform cameraT;
    float velocityY;
    float jumpTime= 0;
    public float jumpspeed = 0.5f;
    CharacterController controler;
    public bool stop;
    [Space]
    [Header("Attacking varables")]
    public Enemy targetedEnemy = null;
    public TargetRange targetRange;
    public TrackObject trackObject;
    [Space]
    [Header("Player Stats")]
    public float maxHealth = 100;
    protected float currentHealth;
    [Space]
    [Header("UI elements")]
    public Text healthText;
    public Slider healthBar;

    void Start () {
        animator = GetComponent<Animator>();
        controler = GetComponent<CharacterController> () ;
        stop = false;
        trackObject.gameObject.SetActive(false);
        currentHealth = maxHealth;
        UpdateHealthUI();


    }

    private void UpdateHealthUI()
    {
        healthBar.value = currentHealth / maxHealth;
        healthText.text = Mathf.Round(currentHealth / maxHealth * 100) + "%";
    }

    // Update is called once per frame


    void Update () {
        if (stop == false)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (inputDir != Vector2.zero)
            {
                float targetrotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetrotation, ref turnsmoothvelocity, turnsmoothtime);
            }
            bool running = Input.GetKey(KeyCode.LeftShift);
            float targetspeed = ((running) ? runspeed : walkspeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetspeed, ref speedsmoothvelocity, speedsmoothtime);
            velocityY += Time.deltaTime * gravity;
            Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
            controler.Move(velocity * Time.deltaTime);
            currentSpeed = new Vector2(controler.velocity.x, controler.velocity.z).magnitude;
            if (controler.isGrounded)
            {
                velocityY = 0;
            }
            float animationSpeedPercent = ((running) ? currentSpeed / runspeed : currentSpeed / walkspeed * .5f);
            animator.SetFloat("Forward", animationSpeedPercent, speedsmoothtime, Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                

                Attack();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
             
                Attack2();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
                SelectEnemy();

        }

        if (controler.isGrounded)
        {
            animator.SetBool("Jumptrue", false);
        }
    }
    
    
    void Jump() {
        if (controler.isGrounded)
        {
            animator.SetBool("Jumptrue", true);
            float jumpvelocity = Mathf.Sqrt(-2 * gravity * jumpheight);
            velocityY = jumpvelocity;
            StartCoroutine(Wait());
        }
       
        
       
    }
    void Attack()
    {
        stop = true; 
        animator.SetBool("Attack", true);
        StartCoroutine(Wait());
        if (targetedEnemy != null && Vector3.Distance(transform.position, targetedEnemy.transform.position) < 2)
        {
            targetedEnemy.TakeDamage(20);
        }
        else
        {
            print("Target too far away!");
        }

    }
    void Attack2()
    {
        stop = true;
        animator.SetBool("Attack2", true);
        StartCoroutine(Wait());
        if (targetedEnemy != null && Vector3.Distance(transform.position, targetedEnemy.transform.position) < 2)
        {
            targetedEnemy.TakeDamage(20);
        }
        else
        {
            print("Target too far away!");
        }

    }

    private IEnumerator Wait()
    {    
        yield return new WaitForSeconds(1.5f/2);
        animator.SetBool("Attack", false);
        animator.SetBool("Attack2", false);       
        stop = false;
     
        
    }

    private void SelectEnemy()
    {
        targetedEnemy = targetRange.GetNextEnemy();
        if (targetedEnemy != null)
        {
            trackObject.gameObject.SetActive(true);
            trackObject.target = targetedEnemy.transform;
        }
        else
        {
            trackObject.gameObject.SetActive(false);
        }
    }

    public void TakeDamage(float attackDamage)
    {
        print("Attacked");
        //simple example of mitigations
        if (UnityEngine.Random.value < 0.1f)
        {
            currentHealth -= attackDamage;
        }
        else
        {
            currentHealth -= attackDamage * 0.2f;  //this would ultimately be determined by the minitgations
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
           
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            print("You're DEAD!");

        }

        UpdateHealthUI();
    }
    
    

}
