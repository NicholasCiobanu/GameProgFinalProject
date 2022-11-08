using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalController : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health == 0)
        {
            animator.SetBool("isDead", true);
        }
    }
}
