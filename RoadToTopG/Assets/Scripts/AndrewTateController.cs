
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AndrewTateController : MonoBehaviour
{
    [SerializeField] KarenController karen1;
    [SerializeField] KarenController karen2;
    [SerializeField] KarenController karen3;
    [SerializeField] KarenController karen4;
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip haramClip;
    private bool playedHaramClip;

    [SerializeField]
    public AudioClip breatheAirClip;
    private bool playedBreatheAirClip;

    [SerializeField]
    public AudioClip cantBanMeClip;
    private bool playedCantBanMeClip;

    [SerializeField]
    public int health;
    Animator animator;

    public float speed = 0.2f;

    [SerializeField]
    private Transform Player;
    
    [SerializeField]
    private GameObject healthText;

    [SerializeField]
    private Text gameWonText;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedHaramClip = false;
        playedBreatheAirClip = false;
        playedCantBanMeClip = false;
        health = 2000;
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (health < 0)
        {
            animator.SetBool("isDead", true);
            // show you win prompt
            StartCoroutine(EndGame());
        }
        
        if (health < 1000 && !playedHaramClip)
        {
            audioSource.PlayOneShot(haramClip);
            playedHaramClip = true;
        } 
        if (health < 500 && !playedBreatheAirClip)
        {
            audioSource.PlayOneShot(breatheAirClip);
            //Player.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 200f);
            playedBreatheAirClip = true;
        } 
        if (health <= 0 && !playedCantBanMeClip)
        {
            audioSource.PlayOneShot(cantBanMeClip);
            playedCantBanMeClip = true;
        } 
        else
        {
            transform.LookAt(Player.gameObject.transform);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    IEnumerator EndGame()
    {
        gameWonText.enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);

        karen1.enabled = false;
        karen2.enabled = false;
        karen3.enabled = false;
        karen4.enabled = false;
    }
    
}
