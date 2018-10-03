using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager Instance;

	public Transform canvas;
    public GameObject pauseMenuPrefab, audioPrefab;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
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
