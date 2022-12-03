using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private RoundManager rm;
    //float roundDelay = 0f;
    //float spawnDelay = 0f;
    int zombies_left = 0;
    bool canSpawn = false;
    bool roundDelay = false;
    // Start is called before the first frame update

    void Start()
    {
        
        rm = FindObjectOfType<RoundManager>();
        for (int i = 0; i < 10; i++)
        {
            GameObject.Instantiate((GameObject)Resources.Load("Normal Variant", typeof(GameObject)), transform.position, Quaternion.identity);
            // Debug.Log("spawned a zombie");


        }
    }


    IEnumerator waiter()
    {

        yield return new WaitForSeconds(10);
        spawnZombies();
        roundDelay= false;
    }

    // Update is called once per frame
    void Update()
    {
        zombies_left = GameObject.FindGameObjectsWithTag("zombie").Length;
        //Debug.Log(zombies_left);
        if (zombies_left == 0)
        {
            //Debug.Log("Round " + rm.getRound() + " ended");
            //Debug.Log("10 seconds to next round");
            if (!roundDelay)
            {
                roundDelay = true;
                StartCoroutine(waiter());
            }

        }

    }
    void spawnZombies()
    {

        for (int i = 0; i < 7; i++)
        {
            GameObject.Instantiate((GameObject)Resources.Load("Normal Variant", typeof(GameObject)), transform.position, Quaternion.identity);
            // Debug.Log("spawned a zombie");


        }
        rm.nextRound();


    }
}
