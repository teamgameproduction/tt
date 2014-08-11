using UnityEngine;
using System.Collections;
	[ExecuteInEditMode]

public class CS_CollectableCounter : MonoBehaviour 
{
	public int collectableCounter = 0;
	
	// Update is called once per frame
	void Update () 
	{
		guiText.text = "Stuff x" + collectableCounter;
	}
}
