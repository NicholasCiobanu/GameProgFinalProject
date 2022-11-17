
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class TateAudioController : MonoBehaviour
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

    [SerializeField]
    private AudioClip haram;
    private bool playedHaram;
    [SerializeField]
    private AudioClip breathAir;
    private bool playedBreathAir;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        playedHaram = false;
        playedBreathAir = false;
        audioSource = GetComponent<AudioSource>();
        health = 100;
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health < 0)
        {
            animator.SetBool("isDead", true);
        } else {
            //NavMeshAgent.SetDestination(Player.position);
            
        }

        if (health < 80 && !playedHaram)
        {
            audioSource.PlayOneShot(haram);
            playedHaram = true;
        }
            
        if (health < 50 && !playedBreathAir)
        {
            audioSource.PlayOneShot(breathAir);
            playedBreathAir = true;
        }


    }

    
        
    
    
}
