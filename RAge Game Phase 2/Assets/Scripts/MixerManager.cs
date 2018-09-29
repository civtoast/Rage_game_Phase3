using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class MixerManager : MonoBehaviour
{

    public AudioMixer mixer;

    public string masterMixer = "master";
    public string ambientMixer = "ambient";
    public string musicMixer = "music";
    public string sfxMixer = "sfx";


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetVolume( string parameter, float volume)
    {

        float audioVolume = Mathf.Log(volume) * 20;
        mixer.SetFloat(parameter, audioVolume);
    }



    public void SetMasterVolume(float volume)
    {
        SetVolume(masterMixer, volume);
    }

    public void SetAmbientVolume(float volume)
    {
        SetVolume(ambientMixer, volume);
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(musicMixer, volume);
    }

    public void SetSfxVolume(float volume)
    {
        SetVolume(sfxMixer, volume);
    }
}
