using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpen : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private Animator secondDoor = null;
    [SerializeField] private bool openTrigger = false;

    [SerializeField] private string firstDoorOpen = "";
    [SerializeField] private string secondDoorOpen = "";

    [SerializeField] private AudioSource doorOpenAudioSource = null;

    [SerializeField] private int cost;
    private MoneyManager mm;
    private RoundManager rm;

    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
        mm = FindObjectOfType<MoneyManager>();
        rm = FindObjectOfType<RoundManager>();

    }

    private void OnTriggerStay(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
            if (gameObject.name.Equals("TiggerOpenAndrewTateBoss"))
            {
                if (Input.GetKey("f") && mm.getMoney() >= cost && rm.getRound() > 7)
                {
                    Destroy(uiObject);
                    mm.RemoveMoney(cost);
                    GameObject[] innerSpawners = GameObject.FindGameObjectsWithTag("innerSpawner");
                    Debug.Log(innerSpawners.Length);
                    foreach (GameObject spawner in innerSpawners)
                    {
                        Debug.Log(spawner.name);
                        spawner.SetActive(true);
                    }
                    if (openTrigger)
                    {
                        myDoor.Play(firstDoorOpen, 0, 0.0f);
                        secondDoor.Play(secondDoorOpen, 0, 0.0f);
                        doorOpenAudioSource.Play();
                        gameObject.SetActive(false);

                    }
                }
            }
            else
            {
                if (Input.GetKey("f") && mm.getMoney() >= cost)
                {
                    Destroy(uiObject);
                    mm.RemoveMoney(cost);
                    GameObject[] innerSpawners = GameObject.FindGameObjectsWithTag("innerSpawner");
                    Debug.Log(innerSpawners.Length);
                    foreach (GameObject spawner in innerSpawners)
                    {
                        Debug.Log(spawner.name);
                        spawner.SetActive(true);
                    }
                    if (openTrigger)
                    {
                        myDoor.Play(firstDoorOpen, 0, 0.0f);
                        secondDoor.Play(secondDoorOpen, 0, 0.0f);
                        doorOpenAudioSource.Play();
                        gameObject.SetActive(false);

                    }
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        uiObject.SetActive(false);
    }


    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(20);
    }
}
