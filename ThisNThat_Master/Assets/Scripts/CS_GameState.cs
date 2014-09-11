using UnityEngine;
using System.Collections;

public class CS_GameState : MonoBehaviour 
{
	[HideInInspector]	public int 			lives = 3;
						public bool 		won = false;
	
	void Start () 
	{

	}

	void Update () 
	{
		if (won)
		{
			CS_HUD.displayResultsScreen = true;
		}
	}

	void RestartLevel()
	{

	}
}
