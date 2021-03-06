﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource currentAudio; // this is the current soundtrack that is playing
    //public  AudioSource newAudio; //  this is the new Audio to load
    public AudioClip newClip;
    private AudioSource holdAudio;
    public float musicVolumeMax = 1f ;
    void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            Debug.Log("audiomanager instance set");
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSoundtrack()
    {
        // will check if the audio to be loaded is already playing if not it loads
        if(newClip == currentAudio.clip)
        {
            return;
        }
        // if there is no audio loaded then it begins immediately
        if(currentAudio.clip == null)
        {
            // code to cause new audio to play begins now
            currentAudio.clip = newClip;
            currentAudio.Play();
            return;
        }
        // begins a co routine that turns down the current audio and turns on the new audio
        StartCoroutine(SoundSwap());
        
    }
    public void VolumeUpdate()
    {
        currentAudio.volume = musicVolumeMax;
    }
    IEnumerator SoundSwap()
    {
        // ramps one soundtrack down, ramps up the next and then sets the new soundtrack to be equal to the old one
        // turns down the audio of the first soundtrack by 1 each frame until reaches 0 then stops it
        while(currentAudio.volume > 0.0f)
        {
            currentAudio.volume = currentAudio.volume - 0.005f;
            yield return 0;
            //wait a frame here
        }
        currentAudio.Stop();
        yield return 0; // wait a frame here
        currentAudio.clip = newClip;
        
        currentAudio.Play();
        currentAudio.volume = 0.0f;

        // plays the audio then turns it up from 0 turns up the audio of the second soundtrack by 1 each frame once the first one is done
        while(currentAudio.volume < musicVolumeMax)
        {
            Debug.Log("Audio turning up");
            currentAudio.volume = currentAudio.volume + 0.005f;
            yield return 0;
            //wait frame here
        }
        //holdAudio = newAudio;
        //currentAudio = newAudio;
        //newAudio = holdAudio;

        // co routine ends 
    }
}
