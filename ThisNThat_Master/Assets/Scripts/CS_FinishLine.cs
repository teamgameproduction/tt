using UnityEngine;
using System.Collections;

public class CS_FinishLine : MonoBehaviour 
{
						public bool 		blueAtFinish = false;
						public bool 		redAtFinish = false;

						private CS_GameState	gameState;
						private CS_Controller	controller;
						private CS_BluePickup	bluePickup;

	void Start () 
	{
		gameState = GameObject.Find ("GameState").GetComponent <CS_GameState>();
		controller = GameObject.Find ("CharacterController").GetComponent <CS_Controller>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent <CS_BluePickup>();
	}
	
	void Update () 
	{
		if (redAtFinish && blueAtFinish)
		{
			gameState.won = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && controller.IsCharacterRed == 2)
			{	blueAtFinish = true;	}
		if (other.gameObject.tag == "Player" && controller.IsCharacterRed == 1)
			{	redAtFinish = true;		}
		if (other.gameObject.tag == "Player" && bluePickup.PickedUp)
			{	redAtFinish = true;
				blueAtFinish = true;}
	}
}
