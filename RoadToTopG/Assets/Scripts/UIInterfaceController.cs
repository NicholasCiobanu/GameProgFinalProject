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
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

         if(zombieAnimator.GetBool("isInRange"))
        {
            StartCoroutine(Damage());
            healthText.GetComponent<Text>().text = "Health: " + playerHealth;
        }
    }

    public IEnumerator Damage() {
        playerHealth -= 5;
        yield return new WaitForSeconds(1000f);
        playerHealth -= 5;
    }
}
