using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{

    GameObject enterShop;
    GameObject player;
    Animation box;
    public GameObject uiObject;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
        enterShop = GameObject.Find("EnterShop");
        uiObject.SetActive(false);
        box = this.transform.parent.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
           
            if (!flag) { 
                uiObject.SetActive(true); 
                flag = true; 
            }
            
            if (Input.GetKey(KeyCode.B))
            {
                uiObject.SetActive(false);
                box.Play("opened_closed");
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        flag = false;
    }
}
