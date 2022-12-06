using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpShop : MonoBehaviour
{
    [SerializeField]
    private GameObject uiObject;
    [SerializeField]
    private Text powerNotif;
    bool flag = false;
    [SerializeField]
    private int cost;
    private MoneyManager mm;

    private UIInterfaceController ic;
    [SerializeField] Weapon m4;
    [SerializeField] Weapon pistol;
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
        if (powerNotif.enabled && (Time.time >= 20))
        {
            powerNotif.gameObject.SetActive(false);
        }
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
                int select = Random.Range(1, 3);

                switch(select)
                {
                    case 1:
                        MoreHealthPower();
                        powerNotif.gameObject.SetActive(true);
                        powerNotif.text = "Power Up acquired: More Health!";
                        break;
                    case 2:
                        DamageUpPower();
                        powerNotif.gameObject.SetActive(true);
                        powerNotif.text = "Power Up acquired: More Damage!";
                        break;
                    default:
                        MoreHealthPower();
                        break;
                }
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

    private void DamageUpPower()
    {
        m4.damage = m4.damage + 5;
        pistol.damage = pistol.damage + 5;
    }

}
