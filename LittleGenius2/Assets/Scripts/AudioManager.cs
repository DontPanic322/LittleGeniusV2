using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicMixer;
    public Slider musicSlider;

    // Update is called once per frame
    public void SetVolume()
    {
        musicMixer.SetFloat("MusicVolume", musicSlider.value);
    }
}
