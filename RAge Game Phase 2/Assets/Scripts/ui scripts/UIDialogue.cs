using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : UICore {

	public Text message;
    public GameObject uiPanel;

	public void Init( GameObject uiPanel)
	{
        uiPanel.active = true;
		//message.text = text;
        ShowPanel();
	}
	
}
