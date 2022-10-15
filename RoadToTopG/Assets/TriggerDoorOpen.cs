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
 public GameObject uiObject;

    void Start() {
        uiObject.SetActive(false);
    }

    private void OnTriggerStay(Collider player) {
        if(player.CompareTag("Player")) {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
            if(Input.GetKey("f")) {
                Destroy(uiObject);
                if (openTrigger) {
                        myDoor.Play(firstDoorOpen, 0, 0.0f);
                        secondDoor.Play(secondDoorOpen, 0, 0.0f);
                        gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
            uiObject.SetActive(false);
    }


    IEnumerator WaitForSec() {
        yield return new WaitForSeconds(20);
 }
}
