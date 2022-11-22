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

    [SerializeField] private Animator kanye = null;
    [SerializeField] private KanyeController kanyeController;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject crosshair1;
<<<<<<< HEAD
    [SerializeField] private GameObject healthText;

    void Start()
    {
=======

    [SerializeField] private Animator AndrewTate = null;
    [SerializeField] private AndrewTateController andrewController;




    void Start()
    {
        TristanTate.GetComponent<Animator>();
        //Sneako.GetComponent<Animator>();
        //Kanye.GetComponent<Animator>();
        //AndrewTate.GetComponent<Animator>();
        


>>>>>>> main
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
<<<<<<< HEAD
        kanye.enabled = (true);

        kanyeController.enabled = (true);
        crosshair.SetActive(true);
        crosshair1.SetActive(true);
        healthText.SetActive(true);
=======
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
>>>>>>> main
    }
}
