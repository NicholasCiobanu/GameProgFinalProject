using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    int selectedWeapon = 0;
    [SerializeField]
    AudioClip equipWeapon;
    [SerializeField]
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1){
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2){
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }

    void SelectWeapon() {
        int i = 0;
        audioSource.Stop();
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                if(!weapon.GetComponent<Weapon>().isReloading)
                {
                audioSource.clip = equipWeapon;
                audioSource.Play();
                }
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
