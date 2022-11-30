using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    private bool isplaying;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        isplaying = false;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")))
        {
            if (!isplaying)
            {
                //Debug.Log("playing");
                audioData.Play(0);
                isplaying = true;
            } 
        }
        else
        {
            if (isplaying)
            {
                //Debug.Log("Stopping");
                isplaying = false;
                audioData.Pause();
            }
        }
    }
}
