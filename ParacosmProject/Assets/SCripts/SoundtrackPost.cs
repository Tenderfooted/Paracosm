using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackPost : MonoBehaviour
{
    
    public AudioClip    clip;
    // Start is called before the first frame update
    void Start()
    {           
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            AudioManager.audioInstance.newClip = clip;
            AudioManager.audioInstance.LoadSoundtrack();
        }
    }
}
