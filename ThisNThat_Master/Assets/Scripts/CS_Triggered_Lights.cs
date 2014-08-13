﻿using UnityEngine;
using System.Collections;

public class CS_Triggered_Lights : MonoBehaviour 
{
	public bool touch;
	public bool lightInteract = true;
	
	
	
	// Use this for initialization
	void Start () 
	{
		touch = false;
		gameObject.light.intensity = 6;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if (Input.GetKeyUp (KeyCode.Q) && gameObject.light.intensity == 6 && lightInteract == true)
		{
			gameObject.light.intensity = 0;
			lightInteract = false;
			StartCoroutine(WaitforLights());
			print ("Lights Off");
		}
		
		if (Input.GetKeyUp (KeyCode.Q) && gameObject.light.intensity == 0 && lightInteract == true)
		{ 
			gameObject.light.intensity = 6;
			lightInteract = false;
			StartCoroutine(WaitforLights());
			print ("Lights On");
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		touch = true;
		print ("I Work Here!");
		
		if (!other.CompareTag ("Player"))
			
		{
			return;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			touch = false;
		}
	}
	
	IEnumerator WaitforLights()
	{
		
		yield return new WaitForSeconds(0.1f);
		lightInteract = true;
		print ("HI");
	}
	
}

