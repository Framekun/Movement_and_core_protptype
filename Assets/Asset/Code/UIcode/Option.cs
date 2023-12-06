using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class Option : MonoBehaviour
{
    public AudioMixer masterAudio;

    Resolution[] resolutions;
    public Dropdown ResDropdown;
    public TMP_Dropdown ResDropDownTMP;
    private void Awake()
    {
        resolutions = Screen.resolutions;

        if (ResDropdown != null) { ResDropdown.ClearOptions(); }
        if (ResDropDownTMP != null)
        {
            ResDropDownTMP.ClearOptions();
        }
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        ResDropDownTMP.AddOptions(options);
        ResDropDownTMP.value = currentResolutionIndex;
        ResDropDownTMP.RefreshShownValue();
        print("Resolutionloaded");
       
    }

    public void SetRes(int ResIndex)
    {
        Resolution res = resolutions[ResIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }


    public void SetVolume(float newvolume)
    {
        //Debug.Log(volume);
        masterAudio.SetFloat("MasterVolume", newvolume);
    }

    public void SetNoise(float newvolume)
    {
        //Debug.Log(volume);
        masterAudio.SetFloat("NoiseVolume", newvolume);
    }

    public void SetMusic(float newvolume)
    {
        //Debug.Log(volume);
        masterAudio.SetFloat("MusicVolume", newvolume);
    }


    public void SetFullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
}
