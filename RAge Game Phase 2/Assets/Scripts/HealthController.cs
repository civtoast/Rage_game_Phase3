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
	

	private void FixedUpdate () {
		if (player.targetedEnemy == null) 
		{
			enemyNameText.text = "Select Enemy";
			healthBar.gameObject.SetActive(false);

		} else
		{
			if (enemyNameText.text != player.targetedEnemy.enemyName)
			{
				healthBar.gameObject.SetActive(true);
				enemyNameText.text = player.targetedEnemy.enemyName;
			}
			UpdateHealthUI();
	
		}
	}

	private void UpdateHealthUI()
	{
		healthBar.value = player.targetedEnemy.GetHealthPertcentage();
		healthText.text = Mathf.Round(player.targetedEnemy.GetHealthPertcentage() * 100) + "%";
	}
}
