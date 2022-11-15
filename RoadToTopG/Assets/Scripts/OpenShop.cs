using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private Animator box;
    [SerializeField]
    private GameObject uiObject;
    bool flag = false;
    [SerializeField]
    private int cost;
    private MoneyManager mm;
    private UIInterfaceController ic;
    // Start is called before the first frame update
    void Start()
    {
        mm = FindObjectOfType<MoneyManager>();
        ic = FindObjectOfType<UIInterfaceController>();
        uiObject.SetActive(false);
        box = this.transform.parent.GetComponent<Animator>();
        box.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            box.enabled = true;
            box.Play("openBox");
            if (!flag) { 
                uiObject.SetActive(true); 
                flag = true; 
            }
            
            if (Input.GetKeyDown(KeyCode.B) && mm.getMoney() >= cost && ic.getHealth() < 100)
            {
                mm.RemoveMoney(cost);
                uiObject.SetActive(false);
                //ic.setHealth(ic.getHealth() + 20);
                Coroutine health = StartCoroutine(AddHealth(.1f));

            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
        flag = false;
        box.Play("closeBox");
    }

    private IEnumerator AddHealth(float time)
    {
        int x;
        if (100 - ic.getHealth() < 20)
        {
             x = 100 - ic.getHealth();
        } else
        {
             x = 20;
        }
        for (int i = 0; i < x; i++)
        {
            if (ic.getHealth() == 100)
            {
                break;
            }
            ic.setHealth(ic.getHealth() + 1);
            yield return new WaitForSeconds(time);
        }
        StopCoroutine(AddHealth(.1f));

    }
}