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
            AudioPlace.loop = true;
        }
        else
        {
            AudioPlace.loop = false;
        }
    }

    void StartAudio()
    {
        AudioPlay = true;
    }
    void StopAudio()
    {
        AudioPlay = false;
    }
}
