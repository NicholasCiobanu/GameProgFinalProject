

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class NormalController : MonoBehaviour
{
    [SerializeField]
    public int health;
    Animator animator;


    [SerializeField]
    private NavMeshAgent agent = null;

    private Transform Player;


    //  Interface
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        GetReference();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (health != 0)
        {
            agent.SetDestination(Player.position);
            float distanceToTarget = Vector3.Distance(transform.position, Player.position);
            if(distanceToTarget <= agent.stoppingDistance)
            {
            RotateToTarget();
            }
            if (distanceToTarget <= 10 && distanceToTarget >= 5)
            {
                Vector3 direction = Player.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = rotation;
            }
        }
        if (health < 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    private void RotateToTarget()
    {
        transform.LookAt(Player);
    }



    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
    }


}
