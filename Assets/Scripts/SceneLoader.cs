using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public GameObject menu;
    public GameObject Control;
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Controls()
    {
        menu.SetActive(false);
        Control.SetActive(true);
    }

    public void menuPage()
    {
        menu.SetActive(true);
        Control.SetActive(false);
    }

}
