/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
	public float delay = 0.5f;
	private string currentTag = "none";

	
	private float timeOut = 0;
	private int index = 0;
	private bool isMoving = false;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
		isMoving = rb.velocity.magnitude > 0.005f;

		if (timeOut < 0 && isMoving)
		{
			timeOut = delay;

			switch (currentTag)
			{
				case "Grass":

					index = index % AudioManager.instance.stepsGrass.Length;
					AudioManager.PlayEffect(AudioManager.instance.stepsGrass, index++);

					break;
				
				case "Ice":

					index = index % AudioManager.instance.stepsIce.Length;
					AudioManager.PlayEffect(AudioManager.instance.stepsIce, index++);

					break;
				
				case "Gravel":

					index = index % AudioManager.instance.stepsGravel.Length;
					AudioManager.PlayEffect(AudioManager.instance.stepsGravel, index++);

					break;
				
				case "Snow":

					index = index % AudioManager.instance.stepsSnow.Length;
					AudioManager.PlayEffect(AudioManager.instance.stepsSnow, index++);

					break;
			}
		}

		timeOut -= Time.deltaTime;
	}

	private void OnCollisionEnter(Collision other)
	{
		currentTag = other.gameObject.tag;
		AudioManager.PlayEffect(AudioManager.instance.land);
	}

	private void OnCollisionExit(Collision other)
	{
		AudioManager.PlayEffect(AudioManager.instance.jump);
	}
}*/
