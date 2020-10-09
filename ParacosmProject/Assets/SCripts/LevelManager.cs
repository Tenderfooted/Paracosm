using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject pauseMenu;
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
        if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == false)
        {
            Debug.Log("AARGH");
            pauseMenu.SetActive(true);
            GameManager.instance.Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeSelf == true)
        {
        
            pauseMenu.SetActive(false);
            GameManager.instance.Resume();
        }
    }
    public void PlayerPush(Vector3 pos)
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = pos;
    }
}
