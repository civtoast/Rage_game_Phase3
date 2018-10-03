using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    public Scene playingScene;
    public Canvas canvas;
    public static bool pause = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                UnpauseGame();
                Time.timeScale = 1;
                Debug.Log(" Game should still be running");
            }
            else
            {
                PauseGame();
                Time.timeScale = 0;
                //CursorLockMode.None;
                Debug.Log(" Game scene should be paused");
            }
        }
		
	}

    public void PauseGame()
    {
        pause = true;
        canvas.enabled = true;

        //public Scene pauseScene = p Time.timeScale;
    }
    public void UnpauseGame()
    {
        pause = false;
        canvas.enabled = false;
    }
}
