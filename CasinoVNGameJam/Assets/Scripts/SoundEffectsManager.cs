using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance;
    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioClip[] soundFXClips;
    

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void PlaySoundEffectClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        //assign audio clip
        audioSource.clip = audioClip;
        
        //assign volume
        audioSource.volume = volume;
        
        //play sound
        audioSource.Play();
        
        //get length of FX clip
        float clipLength = audioSource.clip.length;
        
        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
    
    public void PlayRandomSoundEffectClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {
        //assign random index
        int randomIndex = UnityEngine.Random.Range(0, audioClip.Length);
        //spawn in game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        //assign audio clip
        audioSource.clip = audioClip[randomIndex];
        
        //assign volume
        audioSource.volume = volume;
        
        //play sound
        audioSource.Play();
        
        //get length of FX clip
        float clipLength = audioSource.clip.length;
        
        //destroy the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
    
    
}
