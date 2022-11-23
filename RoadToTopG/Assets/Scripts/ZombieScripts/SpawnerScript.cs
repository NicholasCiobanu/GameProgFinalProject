using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private RoundManager rm;
    float roundDelay = 0f;
    float spawnDelay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rm = FindObjectOfType<RoundManager>();

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= roundDelay)
        {
            Debug.Log("Start of round" + rm.getRound());
            roundDelay = Time.time + 60f;
            for (int i = 0; i < 7; i++)
            {
                StartCoroutine(waiter());

                GameObject.Instantiate((GameObject)Resources.Load("Normal Variant", typeof(GameObject)), transform.position, Quaternion.identity);
               // Debug.Log("spawned a zombie");


            }
            rm.nextRound();
        }
    }
}
