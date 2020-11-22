using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public bool flag = false;
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
            videoPlayer.Play();
        }
    }
}
