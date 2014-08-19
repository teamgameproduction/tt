using UnityEngine;
using System.Collections;

public class CS_Updraft : MonoBehaviour 
{
						//public GameObject gmcharacterRed;
						public GameObject 	gmcharacterBlue;
						public  CS_Controller 	controller;
						//public float RedBounceForce = 600.0f;
						public float 		UpForceSpeed = 8.0f;
						public  CS_FlapReset 	flapReset;
						public bool 		IsInUpdraft = false;

	// Use this for initialization
	void Start () 
	{
		//gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		flapReset = GameObject.Find ("characterBlue").GetComponent< CS_FlapReset>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (IsInUpdraft == true)
		{
			UpForce();
		}
	}

	void UpForce ()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.up * UpForceSpeed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && controller.IsCharacterRed == 2) 
		{
			IsInUpdraft = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player" && controller.IsCharacterRed == 2) 
		{
			IsInUpdraft = false;
		}
	}
}
