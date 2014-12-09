using UnityEngine;
using System.Collections;

public class CS_Generic_Pickup : MonoBehaviour 
{
	public CS_CollectableCounter collectableCounter;
	public bool pickedUp = false;
	
	void Awake()
	{
		collectableCounter = GameObject.Find ("CollectableText").GetComponent<CS_CollectableCounter>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
		print ("I Found A Thing!");
		//Update GUI
		collectableCounter.collectableCounter++;
		pickedUp = true;
		// Set the counter to inactive
		gameObject.renderer.enabled = false;
		gameObject.collider.enabled = false;
		}
	}
}
