using UnityEngine;
using System.Collections;

public class CS_Updraft : MonoBehaviour 
{
						//public GameObject gmcharacterRed;
						public GameObject 	gmcharacterBlue;
						public GameObject 	airVent;
						public  CS_Controller 	controller;
						//public float RedBounceForce = 600.0f;
						public float 		UpForceSpeed = 8.0f;
						public  CS_FlapReset 	flapReset;
						public bool 		IsInUpdraft = false;

						public bool PushUp = true;
						public bool PushDown = false;
						public bool PushRight = false;
						public bool PushLeft = false;

	// Use this for initialization
	void Start () 
	{
		//gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		flapReset = GameObject.Find ("characterBlue").GetComponent< CS_FlapReset>();
		airVent = GameObject.Find ("UpDraft_01");

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (IsInUpdraft == true && PushUp == true)
		{
			UpForce();
		}

		else if (IsInUpdraft == true && PushDown == true)
		{
			DownForce();
		}

		else if (IsInUpdraft == true && PushRight == true){

			RightForce();
		}

		else if (IsInUpdraft == true && PushLeft == true){
			
			LeftForce();
		}
	}

	void UpForce ()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.up * UpForceSpeed);
	}

	void DownForce ()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.up * UpForceSpeed * -1);
	}

	void RightForce ()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.right * UpForceSpeed);
	}

	void LeftForce ()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.right * UpForceSpeed * -1);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == gmcharacterBlue) 
		{
			IsInUpdraft = true;
		}
		if (other.gameObject == airVent) {
				
			UpForceSpeed =0.0f;
		}

	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == gmcharacterBlue) 
		{
			IsInUpdraft = false;
		}

		if (other.gameObject == airVent) {
			
			UpForceSpeed =8.0f;
		}
	}
}
