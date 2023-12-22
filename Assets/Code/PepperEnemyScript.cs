using System.Collections;
using System.Collections.Generic;
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



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        flame.GetComponent<Renderer>().enabled = false;
        flame.GetComponent<BoxCollider>().enabled = false;
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
    }

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

    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            walkPointSet = true;
    }

    private void Chasing()
    {
        agent.SetDestination(player.transform.position);
    }

    private void Attacking()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);


        if (!alreadyAttacked)
        {

            //Attack go here
            flame.GetComponent<Renderer>().enabled = true;
            flame.GetComponent<BoxCollider>().enabled = true;


            ////////////////

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
            

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        flame.GetComponent<Renderer>().enabled = false;
        flame.GetComponent<BoxCollider>().enabled = false;
    }
}
