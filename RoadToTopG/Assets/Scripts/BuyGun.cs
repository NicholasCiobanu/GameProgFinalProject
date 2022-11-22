using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGun : MonoBehaviour
{
    private MoneyManager mm;
    bool flag = false;
    private Weapon currentWeapon;
    [SerializeField]
    private GameObject toBuy;
    [SerializeField]
    private int cost;
    [SerializeField]
    private GameObject uiObject;
    [SerializeField]
    private GameObject guns;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = FindObjectOfType<Weapon>();
        mm = FindObjectOfType<MoneyManager>();
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentWeapon = FindObjectOfType<Weapon>();
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
                currentWeapon.transform.DetachChildren();
                toBuy.transform.parent = guns.transform;
                Debug.Log("Purchased");
            }
        }

    }
}
