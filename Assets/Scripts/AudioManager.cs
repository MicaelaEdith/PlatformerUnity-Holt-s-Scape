using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] music;
    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
        
    }
    void Start()
    {
       // music[0].Play();
        
    }

    
    void Update()
    {

        
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }
}
