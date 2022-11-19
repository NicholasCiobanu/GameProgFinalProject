
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class AndrewTateController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip haramClip;
    private bool playedHaramClip;

    [SerializeField]
    public AudioClip breatheAirClip;
    private bool playedBreatheAirClip;

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
        audioSource = GetComponent<AudioSource>();
        playedHaramClip = false;
        playedBreatheAirClip = false;
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
        else {
            NavMeshAgent.SetDestination(Player.position);
        }
        
        if (health < 80 && !playedHaramClip)
        {
            audioSource.PlayOneShot(haramClip);
            playedHaramClip = true;
        } 
        if (health < 50 && !playedBreatheAirClip)
        {
            audioSource.PlayOneShot(breatheAirClip);
            playedBreatheAirClip = true;
        } 
        


    }
    
}
