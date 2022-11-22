using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    int selectedWeapon = 0;
    [SerializeField]
    AudioClip equipWeapon;
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Texture m4Texture;
    [SerializeField]
    Texture pistolTexture;
    bool gameStart;
    
    public float fireRate = 1f;
    private float nextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameStart  = true;
        SelectWeapon();
        GameObject.Find("m4Silhouette").GetComponent<RawImage>().texture = pistolTexture;
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && SwitchIsEnabled())
        {
            
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && SwitchIsEnabled())
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1 && SwitchIsEnabled()){
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && SwitchIsEnabled()){
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }

    void SelectWeapon() {
        GetComponent<Animator>().SetBool("Reloading",false); 
        int i = 0;
        audioSource.Stop();
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                GameObject.Find("m4Silhouette").GetComponent<Animation>().Play();
                audioSource.clip = equipWeapon;
                audioSource.Play();
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void ChangeSilhouette(){
        if (gameStart){
            gameStart = false;
            return;
        }
        if (GameObject.Find("m4Silhouette").GetComponent<RawImage>().texture == m4Texture)
            GameObject.Find("m4Silhouette").GetComponent<RawImage>().texture = pistolTexture;
        else if (GameObject.Find("m4Silhouette").GetComponent<RawImage>().texture == pistolTexture) 
            GameObject.Find("m4Silhouette").GetComponent<RawImage>().texture = m4Texture;
    }

    bool SwitchIsEnabled(){
        if (Time.time < nextTimeToFire){
            return false;
        }
        nextTimeToFire = Time.time + (1f/fireRate);
        return true;;
    }
}
