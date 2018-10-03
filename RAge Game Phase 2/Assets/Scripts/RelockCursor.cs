using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RelockCursor : MonoBehaviour {


    public Button newGame;
    public static bool isLocked = false;



	// Use this for initialization
	void Start () {
        newGame.onClick.AddListener(LockCursor);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     public void LockCursor()
    {
        if (isLocked)
        {
            GetComponent<Pause>().UnpauseGame();
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log(" Game should still be running");
        }
    }
}
