
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIInterfaceController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    public AudioClip backWhereYouStartedClip;
    private bool playedBackWhereYouStartedClip;
    private int playerMaxHealth = 100;
    private int playerHealth;
    [SerializeField] private Text healthText;
    [SerializeField] private Text gameOverText;
    //public Animator zombieAnimator;
    float nextTimeToAttack = 0f;
    private GameObject player;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playedBackWhereYouStartedClip = false;
        playerHealth = playerMaxHealth;
        player = GameObject.Find("PlayerCapsule");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<HealthController>().health;
        healthText.text = "Health: " + playerHealth + "/" + playerMaxHealth;
        if (playerHealth <= 0 && !playedBackWhereYouStartedClip)
        {
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        audioSource.PlayOneShot(backWhereYouStartedClip);
        playedBackWhereYouStartedClip = true;
        gameOverText.enabled = true;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }

    public IEnumerator Damage()
    {
        yield return new WaitForSeconds(1f);
        playerHealth -= 5;
    }

    public int getHealth()
    {
        return player.GetComponent<HealthController>().health;
    }

    public void setHealth(int health)
    {
        player.GetComponent<HealthController>().health = (health > playerMaxHealth) ? playerMaxHealth : health;
        healthText.text = "Health: " + player.GetComponent<HealthController>().health + " / " + playerMaxHealth;
        Debug.Log(healthText.text);
    }


    public int getMaxHealth()
    {
        return playerMaxHealth;
    }

    public void setMaxHealth(int health)
    {
        int diff = health - playerMaxHealth;
        playerMaxHealth = health;
        player.GetComponent<HealthController>().health += diff;
        healthText.text = "Health: " + player.GetComponent<HealthController>().health + "/" + playerMaxHealth;
    }
}
