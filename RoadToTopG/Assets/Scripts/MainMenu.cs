using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject controlsMenu;
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);

    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
