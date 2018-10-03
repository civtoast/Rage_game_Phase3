using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : UICore {

    public Scene playingScene;
    public Canvas canvas;
    public static bool pause = false;
    

	
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                UnpauseGame();
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Debug.Log(" Game should still be running");
            }
            else
            {
                PauseGame();
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
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
