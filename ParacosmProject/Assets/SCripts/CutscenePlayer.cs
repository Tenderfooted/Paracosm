using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public bool flag = false;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<UnityEngine.Video.VideoPlayer>() != null)
        {
            videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && flag == true)
        {
            ui.SetActive(false);
            videoPlayer.Play();
            //Time.timeScale = 0.0f;
            StartCoroutine(EndCutscene());
        }
    }
    IEnumerator EndCutscene()
    {
        Debug.Log("CountdownStarted");
        yield return new WaitForSeconds(11);
        ui.SetActive(true);
        SceneManager.LoadScene(0);
        //Time.timeScale = 1.0f;
    }
}
