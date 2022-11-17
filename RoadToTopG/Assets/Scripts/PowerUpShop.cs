using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShop : MonoBehaviour
{
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            if (!flag)
            {
                uiObject.SetActive(true);
                flag = true;
            }

            if (Input.GetKeyDown(KeyCode.B) && mm.getMoney() >= cost)
            {
                mm.RemoveMoney(cost);
                uiObject.SetActive(false);
                MoreHealthPower();
                Debug.Log("Purchased");
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
        flag = false;
    }

    private void MoreHealthPower()
    {
        ic.setMaxHealth(ic.getMaxHealth() + 50);
    }

    private void NoReloadPower()
    {

    }

    private void DamageUpPower()
    {

    }

    private void ExplosiveShotPower()
    {

    }
}
