using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    private int currentRound = 1;
    [SerializeField]
    private Text zombies_left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        zombies_left.text ="Zombies left: " + GameObject.FindGameObjectsWithTag("zombie").Length;
    }

    public int getRound()
    {
        return currentRound;
    }
    public void nextRound()
    {
        currentRound++;
    }
}
