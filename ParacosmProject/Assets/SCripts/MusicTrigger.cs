﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.newClip = clip;
            AudioManager.instance.LoadSoundtrack();
        }
    }
}