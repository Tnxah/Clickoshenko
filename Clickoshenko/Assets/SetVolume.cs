using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{


    public AudioMixer mixer;

    private void Start()
    {
        SetLevel(0.3f);
    }

    public void SetLevel(float sliderValue)
    {
        if (AudioController.instance.muted)
        {
            AudioController.instance.MuteUnmute();
        }
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }


}
