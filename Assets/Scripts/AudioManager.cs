using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] music;
    public AudioSource[] sfx;
    public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
        music[0].Play();
        
    }
    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }

    public void setMusic()
    {
        musicMixer.audioMixer.SetFloat("musicVol",UIManager.instance.musicSlider.value);

    }

    public void setSfx()
    {
        musicMixer.audioMixer.SetFloat("sfxVol", UIManager.instance.musicSlider.value);
    }

    public void StopSFX(int sfxToStop)
    {
        sfx[sfxToStop].Stop();

    }

}
