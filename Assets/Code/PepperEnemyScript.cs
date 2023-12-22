using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class PepperEnemyScript : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private GameObject flame;

    [SerializeField] private LayerMask groundMask, playerMask;


    //Patroling 
    [SerializeField] private Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] private float walkPointRange;

    //Chasing

    //Attacking
    [SerializeField] private float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    [SerializeField] private float sightRange, attackRange;
    bool playerInSight, playerInAttack;

    //HP / Alive
    public float HP = 5;
    [SerializeField] GameObject body;
    bool dieNextFrame = false;

    //Sounds
    [SerializeField] private AudioSource belch;
    private Stopwatch belchCooldown = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        flame.GetComponent<Renderer>().enabled = false;
        flame.GetComponent<BoxCollider>().enabled = false;

        belchCooldown.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //Check what range player lies within.
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSight && !playerInAttack)
            Patroling();
        if (playerInSight && !playerInAttack)
            Chasing();
        if (playerInSight && playerInAttack)
            Attacking();


        //If enemy HP <= 0, kills enemy
        if (HP <= 0 )
        {
            if (!dieNextFrame)
            {
                GameObject corpse = Instantiate(body);
                corpse.transform.position = this.transform.position;
                corpse.transform.rotation = this.transform.rotation;
                corpse.transform.localScale = this.transform.localScale ;
            }

            if (dieNextFrame)
                Destroy(this.gameObject);

            dieNextFrame = true;
        }

    }

    //To be called if no player found. 
    private void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    //To be called when looking for a random destination. 
    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointSet = true;
    }

    //To be called when enemy spots player.
    private void Chasing()
    {
        agent.SetDestination(player.transform.position);
    }

    //To be called when enemy is within attack range of player. 
    private void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);


        if (!alreadyAttacked)
        {

            //Attack go here
            belchIfPossible();
            flame.GetComponent<Renderer>().enabled = true;
            flame.GetComponent<BoxCollider>().enabled = true;
            ////////////////

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
            

    }

    //Makes attack invisible if player runs outside of range. 
    private void ResetAttack()
    {
        alreadyAttacked = false;
        flame.GetComponent<Renderer>().enabled = false;
        flame.GetComponent<BoxCollider>().enabled = false;
    }

    private void belchIfPossible()
    {
        if (belchCooldown.ElapsedMilliseconds > 5000)
        {
            belch.Play();
            belchCooldown.Reset();
        }
    }
}
