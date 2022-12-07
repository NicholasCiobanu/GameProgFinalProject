using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCutScenes : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject crosshair1;
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject healtPic;
    [SerializeField] private GameObject money;
    [SerializeField] private GameObject magazine;
    [SerializeField] private GameObject remainingMag;
    [SerializeField] private GameObject diagonalAmmo;
    [SerializeField] private GameObject m4Silhouette;
    [SerializeField] private GameObject zombiesLeft;
    [SerializeField] private GameObject wave;
    [SerializeField] private SpawnerScript spawner;
    [SerializeField] private SpawnerScript spawner2;
    [SerializeField] private SpawnerScript spawner3;
    [SerializeField] private GameObject audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(3);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(6);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(8);
        Cam4.SetActive(true);
        Cam3.SetActive(false);

        crosshair.SetActive(true);
        crosshair1.SetActive(true);
        healthText.SetActive(true);
        healtPic.SetActive(true);
        money.SetActive(true);
        magazine.SetActive(true);
        remainingMag.SetActive(true);
        diagonalAmmo.SetActive(true);
        m4Silhouette.SetActive(true);
        zombiesLeft.SetActive(true);
        wave.SetActive(true);
        spawner.enabled = true;
        spawner2.enabled = true;
        spawner3.enabled = true;
        audioSource.SetActive(true);
    }
}
