using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button saveButton, loadButton, exitButton; // links the buttons in the inspector
    
    void Start()
    {
        saveButton.onClick.AddListener(SaveOnClick);   // tells the button to do this task when clicked
        loadButton.onClick.AddListener(LoadOnClick);
        exitButton.onClick.AddListener(ExitOnClick);
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
        GameManager.instance.ExitGame();
    }
}
