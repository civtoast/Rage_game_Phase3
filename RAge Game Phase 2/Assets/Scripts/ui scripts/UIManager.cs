﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : UICore
{

	public static UIManager Instance;

    public Button changeTo;

	public Transform canvas;
    public GameObject pauseMenuPrefab, audioPrefab;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

    public void BringPauseMenu()
    {
        GameObject obj = Instantiate(pauseMenuPrefab, canvas);
        obj.GetComponent<>();
    }

	/*public void ShowDialogue(string text)
	{
		GameObject obj = Instantiate(pauseMenuPrefab, canvas);
		obj.GetComponent<UIDialogue>().Init(text);
	}

	//public void ShowSettings()
	//{
		//GameObject obj = Instantiate(settingsPrefab, canvas);
		//obj.GetComponent<UISettings>().Init();
	//}

    public void ShowAudioPanel()
    {
        GameObject obj = Instantiate(audioPrefab, canvas);
        obj.GetComponent<UIAudio>().Init();
    }*/



}
