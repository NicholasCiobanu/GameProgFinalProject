
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class SneakoController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip comeBackToRealityClip;
    private bool playedComeBackToRealityClip;

    [SerializeField]
    public AudioClip getOffTheTiktokClip;
    private bool playedGetOffTheTiktokClip;

    [SerializeField]
    public AudioClip youAreSoStupidClip;
    private bool playedYouAreSoStupidClip;

    [SerializeField]
    public int health;
    Animator animator;

    public float speed = 0.2f;

    [SerializeField]
    private GameObject Player;

    [SerializeField] private Animator tristanTate = null;
    [SerializeField] private TristanController tristanController;


    //  Interface
    [SerializeField]
    private GameObject healthText;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedComeBackToRealityClip = false;
        playedGetOffTheTiktokClip = false;
        playedYouAreSoStupidClip = false;
        health = 1200;
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
            transform.LookAt(Player.gameObject.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (health <= 800 && !playedComeBackToRealityClip)
        {
            audioSource.PlayOneShot(comeBackToRealityClip);
            playedComeBackToRealityClip = true;
        }
        if (health <= 400 && !playedGetOffTheTiktokClip)
        {
            audioSource.PlayOneShot(getOffTheTiktokClip);
            playedGetOffTheTiktokClip = true;
        }
        if (health <= 0 && !playedYouAreSoStupidClip)
        {
            audioSource.PlayOneShot(youAreSoStupidClip);
            playedYouAreSoStupidClip = true;
            tristanTate.enabled = (true);
            tristanController.enabled = (true);
        }
    }
}