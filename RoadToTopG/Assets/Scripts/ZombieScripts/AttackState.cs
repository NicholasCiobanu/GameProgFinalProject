using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    
    AudioSource audioSource;
    

    private GameObject player;
    private GameObject zombie;
    private float distance;
    float nextTimeToAttack = 0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("PlayerCapsule");
        zombie = animator.GameObject();
        audioSource = zombie.GetComponent<AudioSource>();
        //audioSource.mute = false;
        audioSource.Play(0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        distance = Vector3.Distance(player.transform.position, zombie.transform.position);

        if (distance > 1 )
        {
            animator.SetBool("isInRange", false);
        }
        else if (Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 0.5f;
            player.GetComponent<HealthController>().health -= 5;
        }
        /*
         *  if (zombieAnimator.GetBool("isInRange") && Time.time >= nextTimeToAttack)
        {   
            nextTimeToAttack = Time.time + 1f;
            playerHealth -= 10;
            Debug.Log("Player health: " + playerHealth);
            healthText.GetComponent<Text>().text = "Health: " + player.GetComponent<HealthController>().health + "/" + playerMaxHealth;
            if (playerHealth <= 0 && !playedBackWhereYouStartedClip)
            {
                audioSource.PlayOneShot(backWhereYouStartedClip);
                playedBackWhereYouStartedClip = true;
                // SceneManager.LoadScene("AbuTateScene");
            }
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
