using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;


    [SerializeField] private Animator TristanTate;
    [SerializeField] private TristanController tristanController;
    [SerializeField] private Animator Sneako = null;
    [SerializeField] private SneakoController sneakoController;
    [SerializeField] private Animator Kanye = null;
    [SerializeField] private KanyeController kanyeController;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject crosshair1;

    [SerializeField] private Animator AndrewTate = null;
    [SerializeField] private AndrewTateController andrewController;




    void Start()
    {
        TristanTate.GetComponent<Animator>();
        //Sneako.GetComponent<Animator>();
        //Kanye.GetComponent<Animator>();
        //AndrewTate.GetComponent<Animator>();
        


        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(8);
        //crosshair.gameObject.SetActive(false);
        //crosshair1.gameObject.SetActive(false);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(9);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        TristanTate.enabled = (true);
        //Sneako.enabled = (true);
        //Kanye.enabled = (true);
        //AndrewTate.enabled = (true);

        //andrewController.enabled = (true);
        //kanyeController.enabled = (true);
        //sneakoController.enabled = (true);
        tristanController.enabled = (true);
        crosshair.SetActive(true);
        crosshair1.SetActive(true);
    }
}
