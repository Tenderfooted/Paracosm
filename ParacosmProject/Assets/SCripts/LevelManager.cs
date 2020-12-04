using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Slider musicSlider;
    public bool isMainMenu = false;
    // Start is called before the first frame update
     void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isMainMenu == false)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && (pauseMenu.activeSelf == false && settingsMenu.activeSelf == false))
            {
                Debug.Log("AARGH");
                pauseMenu.SetActive(true);
                GameManager.instance.Pause();
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && (pauseMenu.activeSelf == true || settingsMenu.activeSelf == true))
            {
            
                pauseMenu.SetActive(false);
                settingsMenu.SetActive(false);
                GameManager.instance.Resume();
            }
        }
    }
    public void PlayerPush(Vector3 pos)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = pos;
    }
    public void SettingsToggle()
    {
        if( settingsMenu.activeSelf == false)
        {
            settingsMenu.SetActive(true);
            pauseMenu.SetActive(false);
            // toggle settings menu on
        }
        else
        {
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
            //toggle off
        }
    }
    public void MusicVolumeChange()
    {
        AudioManager.instance.musicVolumeMax = musicSlider.value;
        AudioManager.instance.VolumeUpdate();
    }
    
}
