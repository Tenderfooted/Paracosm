using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource currentAud;
    public AudioClip newClip;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        currentAud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSoundtrack()
    {
        // Rewriting code from memory
        // check if there is no soundtrack playing. if so play immediately
        if(currentAud.clip == null)
        {
            currentAud.clip = newClip;
            currentAud.Play();
            return;
        }
        // check if thee current soundtrack is the same. if so do nothing
        if(currentAud.clip == newClip)
        {
            return;
        }
        // if all is false then go ahead withthe swap coroutine
        StartCoroutine(MusicSwap());
    }
    IEnumerator MusicSwap()
    {
        // turn current soundtrack down to zero
        while(currentAud.volume > 0.0f)
        {
            currentAud.volume = currentAud.volume - .5f * Time.deltaTime;
            yield return 0;
        }
        // then stop the music
        currentAud.Stop();
        //then load and play new soundtrack
        currentAud.clip = newClip;
        currentAud.Play();
        currentAud.volume = 0f;
        //then turn the volume up from zero to 1
        while(currentAud.volume < 1.0f)
        {
            currentAud.volume = currentAud.volume + .5f * Time.deltaTime;
            yield return 0;
        }
        // nothing else?

    }
}
