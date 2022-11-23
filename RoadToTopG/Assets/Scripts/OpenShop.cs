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
            if (!flag)
            {
                uiObject.SetActive(true);
                flag = true;
            }

            if (Input.GetKeyDown(KeyCode.B) && mm.getMoney() >= cost && ic.getHealth() < ic.getMaxHealth())
            {
                mm.RemoveMoney(cost);
                uiObject.SetActive(false);
                ic.setHealth(ic.getHealth() + 20);
                
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
        flag = false;
        box.Play("closeBox");
    }

}