using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class CS_HUD : MonoBehaviour 
{
						public static bool 	displayResultsScreen;
						public GUIStyle		labelStyle;
						public GUIStyle		buttonStyle;

	void Start () 
	{
		displayResultsScreen = false;
	}

	void Update () 
	{
	
	}

	void OnGUI()
	{
		labelStyle.fontSize = Screen.height / 10;
		buttonStyle.fontSize = Screen.height / 18;

		if (displayResultsScreen)
		{
			GUI.Label(new Rect((Screen.width * 0.5f) / 2, (Screen.height * 0.25f) / 2, Screen.width * 0.5f, Screen.height * 0.25f), "LEVEL COMPLETE!", labelStyle);

			if (GUI.Button(new Rect((Screen.width * 0.5f) / 1.5f, (Screen.height * 0.75f), Screen.width * 0.3f, Screen.height * 0.15f), "CONTINUE", buttonStyle))
			{	Application.LoadLevel ("UI_LevelSelect");	}
		}
	}
}
