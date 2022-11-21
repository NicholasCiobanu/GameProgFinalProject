using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    float delay = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= delay)
        {
            delay = Time.time + 5f;
            GameObject.Instantiate((GameObject)Resources.Load("Normal Variant", typeof(GameObject)));
        }
    }
}
