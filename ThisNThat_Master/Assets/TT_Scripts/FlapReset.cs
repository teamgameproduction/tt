using UnityEngine;
using System.Collections;

//This scripts resets the Flap counters for the player characters

public class FlapReset : MonoBehaviour 
{
						public Controller 	controller;
						public bool 		Grounded;

	// Use this for initialization
	void Start () 
	{
		//gets the Controller script info so it can reference it later
		controller = GameObject.Find ("CharacterController").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player") 
		{
			if (controller.IsCharacterRed == true)
			{
				//if the character is red, reset red's available jumps
				controller.RedFlaps = controller.RedMaxFlaps;
			}
			else
			{
				//otherwise, reset blue's available jumps
			controller.BlueFlaps = controller.BlueMaxFlaps;
			}
		}
		if (other.gameObject.tag == "Slippery") 
		{
			if (controller.IsCharacterRed == true)
			{
				//if the character is red, reset red's available jumps
				controller.RedFlaps = controller.RedMaxFlaps;
				controller.RedOnSlip = true;
			}
			else
			{
				//otherwise, reset blue's available jumps
				controller.BlueFlaps = controller.BlueMaxFlaps;
				controller.BlueOnSlip = true;
			}
		}
			Grounded = true;
		
	}
	void OnCollisionExit(Collision other)
	{
		Grounded = false;
		if(controller.IsCharacterRed == true)
		{
			controller.RedOnSlip = false;
		}
		else
		{
			controller.BlueOnSlip = false;
		}
	}

}
