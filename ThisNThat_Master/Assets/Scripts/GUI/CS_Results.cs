using UnityEngine;
using System.Collections;

public class CS_Results : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Replay()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LevelSelect()
	{
		Application.LoadLevel ("UI_LevelSelect");
	}
}
