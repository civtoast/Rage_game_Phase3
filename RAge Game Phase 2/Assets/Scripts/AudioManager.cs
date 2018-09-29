using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	private AudioSource source;
	
	public AudioClip[] stepsGrass;
	public AudioClip[] stepsSnow;
	public AudioClip[] stepsIce;
	public AudioClip[] stepsGravel;

	public AudioClip jump;
	public AudioClip land;

	public Slider slider;


	// Use this for initialization
	void Start () {
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
		slider.onValueChanged.AddListener(SetAudioVolume);
		
		source = GetComponent<AudioSource>();
		GetAudioVolume();
	}

	

	public static void PlayEffect(AudioClip[] selection, int index)
	{
		instance.source.PlayOneShot(selection[index]);
	}
	
	public static void PlayEffect(AudioClip clip)
	{
		instance.source.PlayOneShot(clip);
	}
	
	private void SetAudioVolume(float volume)
	{
		PlayerPrefs.SetFloat("volume", volume);
		PlayerPrefs.Save();
	}

	public void GetAudioVolume()
	{
		slider.value = PlayerPrefs.GetFloat("volume", 1);
		
	}
}
