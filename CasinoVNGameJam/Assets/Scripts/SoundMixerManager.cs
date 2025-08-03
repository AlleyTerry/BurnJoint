using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;    

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;


    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("MasterVolume", level);
        //adjust the master volume logarithmically
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20);
        
    }
    
    public void SetMusicVolume(float level)
    {
        //audioMixer.SetFloat("MusicVolume", level);
        //adjust the music volume logarithmically
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20);
    }
    
    public void SetSFXVolume(float level)
    {
        //audioMixer.SetFloat("SoundFxVolume", level);
        //adjust the sound effects volume logarithmically
        audioMixer.SetFloat("SoundFxVolume", Mathf.Log10(level) * 20);
    }
}
