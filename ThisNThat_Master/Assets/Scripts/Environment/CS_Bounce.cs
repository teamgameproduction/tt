using UnityEngine;
using System.Collections;

public class CS_Bounce : MonoBehaviour 
{
						public GameObject 	gmcharacterRed;
						public GameObject 	gmcharacterBlue;
						public  CS_Controller 	controller;
						public float 		RedBounceForce = 600.0f;
						public float 		BlueBounceForce = 900.0f;

	// Use this for initialization
	void Start () 
	{
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			print ("get ready to bounce");

			if (controller.IsCharacterRed == 1)
			{
				gmcharacterRed.rigidbody.AddForce (Vector3.up * RedBounceForce);
			}

			else 
			{
				gmcharacterBlue.rigidbody.AddForce (Vector3.up * BlueBounceForce);
			}

		}
	}
}
