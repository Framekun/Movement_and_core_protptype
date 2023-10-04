//using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeStorageSystem : MonoBehaviour
{
    public float VolumeMaster;
    public float VolumeMusic;
    public float VolumeSound;

    private void Start()
    {
        
        PlayerPrefs.SetFloat("SetVolumeMaster", VolumeMaster);
        PlayerPrefs.SetFloat("SetVolumeMusic", VolumeMusic);
        PlayerPrefs.SetFloat("SetVolumeSound", VolumeSound);
    }
}
