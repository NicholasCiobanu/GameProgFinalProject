
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
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject gameOverText;
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
        healthText.GetComponent<Text>().text = "Health: " + playerHealth + "/" + playerMaxHealth;
        if (playerHealth <= 0 && !playedBackWhereYouStartedClip)
        {
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        audioSource.PlayOneShot(backWhereYouStartedClip);
        playedBackWhereYouStartedClip = true;
        gameOverText.GetComponent<Text>().enabled = true;
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
        return playerHealth;
    }

    public void setHealth(int health)
    {
        playerHealth = health;
        healthText.GetComponent<Text>().text = "Health: " + playerHealth + "/" + playerMaxHealth;
    }

    public int getMaxHealth()
    {
        return playerMaxHealth;
    }

    public void setMaxHealth(int health)
    {
        playerMaxHealth = health;
        healthText.GetComponent<Text>().text = "Health: " + playerHealth + "/" + playerMaxHealth;
    }
}
