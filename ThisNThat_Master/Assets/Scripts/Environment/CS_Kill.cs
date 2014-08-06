using UnityEngine;
using System.Collections;

public class CS_Kill : MonoBehaviour 
{
	private CS_GameState gameState;

	void Start () 
	{
		gameState = GameObject.Find ("GameState").GetComponent< CS_GameState>();
	}
	
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (gameState.lives > 0)
			{
				//Play Death Animation
				gameState.lives--;
			}
			else
			{
				//Restart Sequence
			}
		}
	}
}
