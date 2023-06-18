using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    int musicVolume;
    int sfxVolume;

    // Start is called before the first frame update
    void Awake()
    {
        musicVolume = 50;
        sfxVolume = 50;
    }

    public void UpdateMusicVolume(Slider slider)
    {
        musicVolume = (int) slider.value;
    }

    public void UpdateSfxVolume(Slider slider)
    {
        sfxVolume = (int) slider.value;
    }
}
