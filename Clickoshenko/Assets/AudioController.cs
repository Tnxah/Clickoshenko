using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public GameObject audio;
    AudioSource audioSource;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AudioController").Length > 1)
        {
            Destroy(this.gameObject);
            Destroy(audio);
        }

        if (instance == null)
        {
            instance = this;
        }

        audioSource = audio.GetComponent<AudioSource>();
        audioSource.Play();
        DontDestroyOnLoad(audioSource);
        DontDestroyOnLoad(this);

    }

    public bool muted = false;

    public AudioMixer mixer;

    float lastValue = -80;         //10
    float currentValue; //10    //0

    private void Start()
    {
        mixer.GetFloat("MusicVol", out currentValue);
    }

    public void MuteUnmute()
    {
       
        currentValue = lastValue;
        
        
        mixer.GetFloat("MusicVol", out lastValue);
        mixer.SetFloat("MusicVol", currentValue);

        muted = !muted;
    }
}
