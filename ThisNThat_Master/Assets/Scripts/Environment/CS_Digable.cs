using UnityEngine;
using System.Collections;

public class CS_Digable : MonoBehaviour 
{
						public bool 			IsRedTouching = false;
	[HideInInspector]	public  CS_Controller 	controller;
	[HideInInspector]	public  CS_BluePickup 	bluePickup;

	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent< CS_BluePickup>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown ("r") && IsRedTouching == true && controller.IsCharacterRed == true ||
		    Input.GetKeyDown ("r") && IsRedTouching == true && bluePickup.PickedUp == true)
		{
			Destroy (gameObject);
		}*/
	}

	void OnMouseDown()
	{
		if (IsRedTouching == true && controller.IsCharacterRed == 1 || IsRedTouching == true && bluePickup.PickedUp == true)
		{
			print ("gfgfdg");
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "characterRed") 
		{
			Debug.Log ("I dig that");
			IsRedTouching = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "characterRed") 
		{
			IsRedTouching = false;
		}
	}

}
