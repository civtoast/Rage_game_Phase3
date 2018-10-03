using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	[Header("Audio Settings")]
	public AudioMixer mixer;

	public string masterVolParameter = "Master";
	public string ambientVolParameter = "Ambient";
	public string musicVolParameter = "Music";
	public string sfxVolParameter = "SFX";

	[Header("Audio Settings UI")]
	public Canvas audioSettingsUI;
	public Slider masterSlider, ambientSlider, musicSlider, sfxSlider;

	public static bool isMenuOpen = false;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	void Start()
	{
		LoadAudioSettings();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isMenuOpen)
			{
				CloseMenu();
			}
			else
			{
				OpenMenu();
			}
		}
	}

	public void LoadAudioSettings()
	{
		masterSlider.value = PlayerPrefs.GetFloat(masterVolParameter);
		ambientSlider.value = PlayerPrefs.GetFloat(ambientVolParameter);
		musicSlider.value = PlayerPrefs.GetFloat(musicVolParameter);
		sfxSlider.value = PlayerPrefs.GetFloat(sfxVolParameter);
	}

	public void SetMasterVolume(float value)
	{
		SetVolumeLevel(masterVolParameter, value);
	}
	public void SetAmbientVolume(float value)
	{
		SetVolumeLevel(ambientVolParameter, value);
	}
	public void SetMusicVolume(float value)
	{
		SetVolumeLevel(musicVolParameter, value);
	}
	public void SetSfxVolume(float value)
	{
		SetVolumeLevel(sfxVolParameter, value);
	}

	private void SetVolumeLevel(string parameter, float value)
	{
		float linearisedVolume = Mathf.Log(value) * 20f;
		mixer.SetFloat(parameter, linearisedVolume);
		PlayerPrefs.SetFloat(parameter, value);
	}

	public void OpenMenu()
	{
		isMenuOpen = true;
		audioSettingsUI.enabled = true;
	}
	public void CloseMenu()
	{
		isMenuOpen = false;
		audioSettingsUI.enabled = false;
	}
}
