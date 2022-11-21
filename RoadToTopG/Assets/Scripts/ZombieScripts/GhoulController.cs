
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class GhoulController : MonoBehaviour
{
    [SerializeField]
    public int health;
    Animator animator;



    [SerializeField]
    private NavMeshAgent NavMeshAgent;

    [SerializeField]
    private Transform Player;


    //  Interface
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {

        health = 80;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (health < 0)
        {
            animator.SetBool("isDead", true);
        }
        else
        {
            NavMeshAgent.SetDestination(Player.position);

        }


    }





}
