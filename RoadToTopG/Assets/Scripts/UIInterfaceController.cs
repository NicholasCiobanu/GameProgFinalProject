
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInterfaceController : MonoBehaviour
{
    // Start is called before the first frame update
     public int playerHealth = 100;
     [SerializeField] private GameObject healthText;
     public Animator zombieAnimator;
     float nextTimeToAttack = 0f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

         if(zombieAnimator.GetBool("isInRange") && Time.time >= nextTimeToAttack)
        {   
            nextTimeToAttack = Time.time + 1f;
            playerHealth -= 10;
            healthText.GetComponent<Text>().text = "Health: " + playerHealth;
        }
    }

    public IEnumerator Damage() {
        yield return new WaitForSeconds(1f);
        Debug.Log("Damage");
        playerHealth -= 5;
    }
}
