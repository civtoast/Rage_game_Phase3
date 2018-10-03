using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Click : MonoBehaviour {

    public Button click;
    public static bool isClicked;
    public Canvas can;


	// Use this for initialization
	void Start () {

      
	}
	
	// Update is called once per frame
	void Update () {
        click.onClick.AddListener(ChangeCanvasForward);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangeCanvasBack();
        }
    }
   
    public void ChangeCanvasForward()
    {

        isClicked = true;
        can.enabled = true;
    }

    public void ChangeCanvasBack()
    {
            isClicked = false;
            can.enabled = false;
    }
}
