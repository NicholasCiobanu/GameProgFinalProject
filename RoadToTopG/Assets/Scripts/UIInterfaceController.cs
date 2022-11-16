
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInterfaceController : MonoBehaviour
{
    // Start is called before the first frame update
    private int playerMaxHealth = 100;
    private int playerHealth;
    [SerializeField] private GameObject healthText;
    public Animator zombieAnimator;
    float nextTimeToAttack = 0f;
    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if(zombieAnimator.GetBool("isInRange") && Time.time >= nextTimeToAttack)
        {   
            nextTimeToAttack = Time.time + 1f;
            playerHealth -= 10;
            healthText.GetComponent<Text>().text = "Health: " + playerHealth + "/" + playerMaxHealth;
        }
    }

    public IEnumerator Damage() {
        yield return new WaitForSeconds(1f);
        Debug.Log("Damage");
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
