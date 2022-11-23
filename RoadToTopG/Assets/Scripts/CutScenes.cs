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
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject healtPic;
    [SerializeField] private GameObject money;
    [SerializeField] private GameObject magazine;
    [SerializeField] private GameObject remainingMag;
    [SerializeField] private GameObject diagonalAmmo;
    [SerializeField] private GameObject m4Silhouette;
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(8);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(9);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        kanye.enabled = (true);

        kanyeController.enabled = (true);
        crosshair.SetActive(true);
        crosshair1.SetActive(true);
        healthText.SetActive(true);
        healtPic.SetActive(true);
        money.SetActive(true);
        magazine.SetActive(true);
        remainingMag.SetActive(true);
        diagonalAmmo.SetActive(true);
        m4Silhouette.SetActive(true);
    }
}