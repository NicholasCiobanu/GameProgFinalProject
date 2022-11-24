

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
    private NavMeshAgent NavMeshAgent;
    //[SerializeField] float speed = 1.5f;

    private Transform Player;


    //  Interface
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        health = 100;
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
            transform.LookAt(Player.gameObject.transform);
            //     transform.LookAt(Player.gameObject.transform);
            //     transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }


    }
}
