
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class KanyeController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip iGuessWellNeverKnowClip;
    private bool playedIGuessWellNeverKnowClip;

    [SerializeField]
    public AudioClip bushDoesntCareClip;
    private bool playedBushDoesntCareClip;

    [SerializeField]
    public int health;
    Animator animator;

    [SerializeField] private Animator sneako = null;
    [SerializeField] private SneakoController sneakoController;

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
        audioSource = GetComponent<AudioSource>();
        playedIGuessWellNeverKnowClip = false;
        playedBushDoesntCareClip = false;
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
        else {
            NavMeshAgent.SetDestination(Player.position);
        }

        if (health < 80 && !playedBushDoesntCareClip)
        {
            audioSource.PlayOneShot(bushDoesntCareClip);
            playedBushDoesntCareClip = true;
        } 
        if (health <= 0 && !playedIGuessWellNeverKnowClip)
        {
            audioSource.PlayOneShot(iGuessWellNeverKnowClip);
            playedIGuessWellNeverKnowClip = true;
            sneako.enabled = (true);
            sneakoController.enabled = (true);
        }



    }
    
}
