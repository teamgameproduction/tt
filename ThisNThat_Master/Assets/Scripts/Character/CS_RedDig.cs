using UnityEngine;
using System.Collections;

public class CS_RedDig : MonoBehaviour 
{
						public  CS_Controller 	controller;
						public GameObject 	TriggeringDirt;
	
	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("F") || Input.GetAxis ("Right_Trigger") >0 && controller.IsCharacterRed == 1)
		{
			Destroy (TriggeringDirt);
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == " CS_Digable") 
		{
			Debug.Log ("I dig that");
			TriggeringDirt = other.gameObject;
		}
	}
}
