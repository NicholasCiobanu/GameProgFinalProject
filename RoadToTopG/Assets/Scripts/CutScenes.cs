using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;


[SerializeField] private Animator TristanTate = null;
[SerializeField] private Animator Sneako = null;
[SerializeField] private Animator Kanye = null;
[SerializeField] private Animator AndrewTate = null;



 void Start()
    {
  TristanTate.GetComponent<Animator>();
  Sneako.GetComponent<Animator>();
  Kanye.GetComponent<Animator>();
  AndrewTate.GetComponent<Animator>();
  StartCoroutine (TheSequence());
    }

    IEnumerator TheSequence() {
        yield return new WaitForSeconds(8);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(9);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        TristanTate.enabled = (true);
        Sneako.enabled = (true);
        Kanye.enabled = (true);
        AndrewTate.enabled = (true);
 }
}
