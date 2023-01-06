using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCutScenes : MonoBehaviour
{
    [SerializeField] private GameObject Cam1;
    [SerializeField] private GameObject Cam2;
    [SerializeField] private GameObject Cam3;
    [SerializeField] private GameObject Cam4;
    [SerializeField] private GameObject Cam5;

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
    [SerializeField] private GameObject audioSourceCutScene;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject skipCutScene;
    [SerializeField] private StarterAssets.FirstPersonController FirstPersonController;
    Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        coroutine = StartCoroutine(TheSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hey");
            StopCoroutine(coroutine);
            turnCameroOff(Cam1);
            turnCameroOff(Cam2);
            turnCameroOff(Cam3);
            turnCameroOff(Cam4);
            skipCutScene.SetActive(false);
            audioSourceCutScene.SetActive(false);
            Cam5.SetActive(true);
            Player.SetActive(true);
            FirstPersonController.enabled = true;
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
            FirstPersonController.enabled = true;

        }
    }

    void turnCameroOff(GameObject Cam)
    {
        Cam.SetActive(false);
    }

    IEnumerator TheSequence()
    {
        skipCutScene.SetActive(true);
        yield return new WaitForSeconds(3);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(6);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(8);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
        Cam5.SetActive(true);

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
        FirstPersonController.enabled = true;
        Player.SetActive(true);
        skipCutScene.SetActive(false);
    }
}
