
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveText : MonoBehaviour
{
    [SerializeField] 
    private Text text;
    private Color col;
    private RoundManager rm;
    private int currentRound = 0;

    bool doneWaiting = false;
    bool roundChange = false;
    bool fadeIn = false;
    bool fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        rm = FindObjectOfType<RoundManager>();
        col=text.color;
        col.a = 0;
        text.color=col;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentRound!=rm.getRound())
        {
            
            Debug.Log(rm.getRound());
            Debug.Log("Round " + rm.getRound() + " started");
            fadeIn = true;
            Debug.Log(fadeIn);
            currentRound = rm.getRound();
            text.text = "Wave " + ((rm.getRound()-1)/3 + 1);
        }

        

        if(col.a<1 && fadeIn)
        {
            col.a+=Time.deltaTime;
            text.color=col;
        } else if(!doneWaiting){
            fadeIn = false;
            doneWaiting = true;
            StartCoroutine(waveTextTime(5));
        }

        if(col.a>0 && fadeOut && doneWaiting)
        {
            int debug = (int)col.a;
            Debug.Log("fadeout: " + debug);
            col.a-=Time.deltaTime;
            text.color=col;
        } else{
            doneWaiting = false;
            fadeOut = false;
        }

    }

    IEnumerator waveTextTime(int time){
        yield return new WaitForSeconds(time);
        fadeOut = true;
    }
}
