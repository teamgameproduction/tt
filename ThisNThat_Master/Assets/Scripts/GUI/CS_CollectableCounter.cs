using UnityEngine;
using System.Collections;

public class CS_CollectableCounter : MonoBehaviour 
{
	public int collectableCounter = 0;
	
	// Update is called once per frame
	void Update () 
	{
		//Set the coiin count text
		guiText.text = "Stuff x" + collectableCounter;

	}
}
