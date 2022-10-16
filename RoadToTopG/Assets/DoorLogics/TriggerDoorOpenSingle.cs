using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpenSingle : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool openTrigger = false;
 [SerializeField] private string doorOpen = "";
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
                        myDoor.Play(doorOpen, 0, 0.0f);
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
