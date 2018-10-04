using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum EnemyArenaState
{
    Patrol,
    Chase,
    Dead
}

public class Enemy : MonoBehaviour
{
    private EnemyArenaState state = EnemyArenaState.Patrol;
    private NavMeshAgent agent;
    public WaypointSolver wpSolver;
    public GameObject player;
    public Animator animator;
   // public Enemycontoller enemy;
    private bool dmghit;
    
    [Space]
    [Header("Enemy Stats")]
    public float maxHealth = 100;
    public string enemyName;
    protected float currentHealth;
    public float minAttackDelay = 1, maxAttackdelay = 4;
    private float timeToNextAttack = 0;

    [Space]
    [Header("UI elements")]
    //public Text enemyNameText;
    public Text healthText;
    public Slider healthBar;
    private Playercontroller play;
    


    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = GameObject.FindGameObjectWithTag("Player");
        state = EnemyArenaState.Chase;
        currentHealth = maxHealth;
        UpdateHealthUI();
        play = FindObjectOfType<Playercontroller>();
        //Enemycontoller
        //enemy = GameObject.Find("Enemy count").GetComponent<Enemycontoller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
             state = EnemyArenaState.Chase;
             animator.SetBool("Attack", true);
             wpSolver.StopPatrolling();
             //wpSolver.StopPatrolling();
             dmghit = true;
            print(dmghit);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == EnemyArenaState.Chase)
            {
                print("wololo");
                state = EnemyArenaState.Patrol;
                wpSolver.StartPatrolling();
                animator.SetBool("Attack", false);
                dmghit = false;

            }
        }
    }

    
    void Update()
    {
        
        if (state == EnemyArenaState.Dead)
        {
            //enemy.enemycount -= 1;
            if (Spawnmanager.enemywave.Contains(this))
            {
              Spawnmanager.enemywave.Remove(this);
            }
            
            agent.enabled = false;
            animator.SetBool("Dead", true);
            

        }
        else 
        {
            animator.SetFloat("Walk", agent.velocity.magnitude);
        }
      //  if (state == EnemyArenaState.Chase)
       // {
         agent.SetDestination(player.transform.position);
       // }
        if (state == EnemyArenaState.Chase && timeToNextAttack < 0 && dmghit == true)
        {
            print("wow");
            timeToNextAttack = Random.Range(minAttackDelay, maxAttackdelay);
            agent.SetDestination(player.transform.position);

            play.TakeDamage(10);

        }
        timeToNextAttack -= Time.deltaTime;
    }
    private void UpdateHealthUI()
    {
        healthBar.value = currentHealth / maxHealth;
        healthText.text = Mathf.Round(currentHealth / maxHealth * 100) + "%";
    }



    public void TakeDamage(float attackDamage)
    {
        
       
        if (Random.value < 0.1f)
        {
            currentHealth -= attackDamage;
        }
        else
        {
            
            currentHealth -= attackDamage * 0.2f;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //wpSolver.SetState(PatrolState.Dead);
            state = EnemyArenaState.Dead;
        }

        UpdateHealthUI();
    }



    public float GetHealthPertcentage()
    {
        return currentHealth / maxHealth;
    }

    public void Dead()
    {
        print("dead");
        Destroy(this.gameObject);
    }      

}