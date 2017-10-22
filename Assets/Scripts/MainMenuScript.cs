using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {
    public GameObject mainPanel;
    public GameObject saveGamePanel;
    public GameObject optionsPanel;

    // Universal

    public void OnPressBackToMain()
    {
        if (!mainPanel.activeInHierarchy)
            mainPanel.SetActive(true);
        if (saveGamePanel.activeInHierarchy)
            saveGamePanel.SetActive(false);
        if (optionsPanel.activeInHierarchy)
            optionsPanel.SetActive(false);
    }

    // Main panel

    public void OnPressStart()
    {
        if (!saveGamePanel.activeInHierarchy)
            saveGamePanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OnPressOptions()
    {
        if (!optionsPanel.activeInHierarchy)
            optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void OnPressQuit()
    {
        Application.Quit();
    }

    // Save game panel

    public void OnPressSave1()
    {

    }

    public void OnPressSave2()
    {

    }

    public void OnPressSave3()
    {

    }
}
