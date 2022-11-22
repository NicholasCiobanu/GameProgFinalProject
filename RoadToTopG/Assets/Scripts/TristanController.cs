
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class TristanController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip youNeedTobeMoreMisogynisticClip;
    private bool playedYouNeedTobeMoreMisogynisticClip;

    [SerializeField]
    public AudioClip dontBeMisogynisticClip;
    private bool playedDontBeMisogynisticClip;

    [SerializeField]
    public int health;
    Animator animator;

    [SerializeField] GameObject women;
    [SerializeField] GameObject women2;
    [SerializeField] GameObject women3;
    [SerializeField] GameObject women4;



    [SerializeField]
    private NavMeshAgent NavMeshAgent;

    [SerializeField]
    private Transform Player;

    [SerializeField] private Animator andrewTate = null;
    [SerializeField] private AndrewTateController andrewController;


    //  Interface
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedYouNeedTobeMoreMisogynisticClip = false;
        playedDontBeMisogynisticClip = false;
        health = 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (health <= 0)
        {
            animator.SetBool("isDead", true);
        }
        else
        {
            NavMeshAgent.SetDestination(Player.position);
        }

        if (health <= 80 && !playedYouNeedTobeMoreMisogynisticClip)
        {
            audioSource.PlayOneShot(youNeedTobeMoreMisogynisticClip);
            playedYouNeedTobeMoreMisogynisticClip = true;
        }
        // if (health <= 50 && !playedGetOffTheTiktokClip)
        // {
        //     audioSource.PlayOneShot(getOffTheTiktokClip);
        //     playedGetOffTheTiktokClip = true;
        // } 
        if (health <= 0 && !playedDontBeMisogynisticClip)
        {
            audioSource.PlayOneShot(dontBeMisogynisticClip);
            playedDontBeMisogynisticClip = true;
            women.SetActive(true);
            women2.SetActive(true);
            women3.SetActive(true);
            women4.SetActive(true);

            andrewTate.enabled = (true);
            andrewController.enabled = (true);
        }
    }
}
