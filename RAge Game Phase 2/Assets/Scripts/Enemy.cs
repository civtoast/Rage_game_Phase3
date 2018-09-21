using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum EnemyState
{
    Patrol,
    Chase,
    Dead
}

public class Enemy : MonoBehaviour
{
    private EnemyState state = EnemyState.Patrol;
    private NavMeshAgent agent;
    private WaypointSolver wpSolver;
    public GameObject player;
    public Animator animator;
    public Enemycontoller enemy;
    private bool dmghit;
    public HealthController score;
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
    public Enemycontoller enemycontr;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wpSolver = GetComponent<WaypointSolver>();
        player = GameObject.FindGameObjectWithTag("Player");

        state = EnemyState.Chase;
        //enemyNameText.text = enemyName;
        currentHealth = maxHealth;
        UpdateHealthUI();
        play = FindObjectOfType<Playercontroller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            state = EnemyState.Chase;
            animator.SetBool("Attack", true);
            wpSolver.StopPatrolling();
            dmghit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (state == EnemyState.Chase)
            {
                //state = EnemyState.Patrol;
                //wpSolver.StartPatrolling();
                animator.SetBool("Attack", false);
                dmghit = false;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EnemyState.Dead)
        {
            enemycontr.enemycount -= 1;
            score.scorenum += 1;
            Destroy(this.gameObject);
           
        }
        animator.SetFloat("Walk", agent.velocity.magnitude);
        agent.SetDestination(player.transform.position);
        if (state == EnemyState.Chase && timeToNextAttack < 0 && dmghit == true)
        {
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
        print("wow");
        //simple example of damage calculators and mitigations
        if (Random.value < 0.1f)
        {
            currentHealth -= attackDamage;
        }
        else
        {
            //this would ultimately be determined by the minitgations
            currentHealth -= attackDamage * 0.2f;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            //wpSolver.SetState(PatrolState.Dead);
            state = EnemyState.Dead;



        }

        UpdateHealthUI();
    }

    public float GetHealthPertcentage()
    {
        return currentHealth / maxHealth;
    }

         

}