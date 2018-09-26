using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	//This script updates the selected enemy's health to the UI system
	
	[Space]
	[Header("UI elements")]
	public Text enemyNameText;
	public Text healthText;
    
	public Slider healthBar;
    private Playercontroller player;
    public int scorenum;
    private void Start()
    {
      
    }
    private void LateUpdate()
    {
        
    }
    private void FixedUpdate () {

		if (Playercontroller.targetedEnemy == null) 
		{
			enemyNameText.text = "Select Enemy";
			healthBar.gameObject.SetActive(false);

		} else
		{
			if (enemyNameText.text != Playercontroller.targetedEnemy.enemyName)
			{
				healthBar.gameObject.SetActive(true);
				enemyNameText.text = Playercontroller.targetedEnemy.enemyName;
			}
			UpdateHealthUI();
	
		}
	}

	private void UpdateHealthUI()
	{
		healthBar.value = Playercontroller.targetedEnemy.GetHealthPertcentage();
		healthText.text = Mathf.Round(Playercontroller.targetedEnemy.GetHealthPertcentage() * 100) + "%";
	}
}
