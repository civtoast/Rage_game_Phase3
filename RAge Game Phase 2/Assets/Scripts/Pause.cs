using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    // public Scene playingScene;
     public Canvas canvas;
    public static bool pause = false;
    //public Button newGame;

    private void Start()
    {
       //  newGame.onClick.AddListener();
    }


    // Update is called once per frame
    void Update()
    {

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



            /* if (Input.GetKeyDown(KeyCode.Space))
             {
                pause = false;

                    // PauseGame();
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Debug.Log(" Game scene should be paused");

            }*/

        
    }

        public void PauseGame()
         {
             pause = true;
             canvas.enabled = true;
         }
         public void UnpauseGame()
         {
             pause = false;
             canvas.enabled = false;
         }
    }

