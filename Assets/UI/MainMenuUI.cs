using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject controlsUI;

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowControlsUI()
    {
        mainUI.SetActive(false);
        controlsUI.SetActive(true);
    }

    public void HideControlsUI()
    {
        mainUI.SetActive(true);
        controlsUI.SetActive(false);
    }
}
