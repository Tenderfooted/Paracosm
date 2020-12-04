using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button saveButton, loadButton, exitButton, launchButton, settingsButton, settingsExitButton, exitGameButton; // links the buttons in the inspector
    //public Slider musicSlider;
    public bool mainMenuProxy = false;

    void Start()
    {   if(mainMenuProxy == true)
        {
            launchButton.onClick.AddListener(LaunchGameButton);
            settingsButton.onClick.AddListener(SettingsOnClick);
            settingsExitButton.onClick.AddListener(SettingsExitOnClick);
            loadButton.onClick.AddListener(LoadOnClick);
            exitGameButton.onClick.AddListener(ExitGame);
        }
        else
        {
            saveButton.onClick.AddListener(SaveOnClick);   // tells the button to do this task when clicked
            loadButton.onClick.AddListener(LoadOnClick);
            exitButton.onClick.AddListener(ExitOnClick);
            settingsButton.onClick.AddListener(SettingsOnClick);
            settingsExitButton.onClick.AddListener(SettingsExitOnClick);
        }
    }

    void SaveOnClick()
    {
        Debug.Log("Save button Pressed wow");
        GameManager.instance.SaveGame();
    }
    void LoadOnClick()
    {
        GameManager.instance.LoadGame();
    }
    void ExitOnClick()
    {
        GameManager.instance.ExitToMenu();
    }
    void SettingsOnClick()
    {
        LevelManager.instance.SettingsToggle();
    }
    void SettingsExitOnClick()
    {
        LevelManager.instance.SettingsToggle();
    }
    void LaunchGameButton()
    {
        GameManager.instance.LaunchGame();
    }
    void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
