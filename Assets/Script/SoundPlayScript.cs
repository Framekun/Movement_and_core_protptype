using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundPlayScript : MonoBehaviour
{
    public bool AudioPlay;
    [SerializeField] AudioSource AudioPlace;
        void Start()
    {
        
    }

    
    void Update()
    {
        if(AudioPlay == true)
        {
            AudioPlace.Play();
            
        }
        else
        {
            AudioPlace.Stop();
        }
    }

    public void StartAudio()
    {
        AudioPlay = true;
    }
    public void StopAudio()
    {
        AudioPlay = false;
    }
    public void PlayAudioOnce()
    {
        AudioPlace.Play();
    }
}
