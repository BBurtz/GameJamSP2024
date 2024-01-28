using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    public Slider Slider;

    public AudioMixer Mixer;

    public AudioManager MusicManager;

    private void Start()
    {
        MusicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioManager>();
        Slider.value = MusicManager.Volume;
        
    }

    public void SetLevel(float SliderValue)
    {
        Mixer.SetFloat("SFXmixer", Mathf.Log10(SliderValue) * 20);
        MusicManager.Volume = SliderValue;
    }
}
