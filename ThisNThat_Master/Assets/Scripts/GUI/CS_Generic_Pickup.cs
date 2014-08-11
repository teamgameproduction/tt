using UnityEngine;
using System.Collections;

public class CS_Generic_Pickup : MonoBehaviour 
{
	private CS_CollectableCounter collectableCounter;

	void Awake()
	{
		collectableCounter = GameObject.Find ("CollectableText").GetComponent<CS_CollectableCounter>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
			print ("You Found A Thing!");
		//Update GUI
		collectableCounter.collectableCounter++;
		// Set the counter to inactive
		gameObject.SetActive (false);
	}
}
