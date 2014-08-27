using UnityEngine;
using System.Collections;

public class CS_MainMenu : MonoBehaviour 
{
						public enum 		ButtonType {Null, Continue, NewGame, Options}
						public ButtonType 	button;
	[HideInInspector]	public string 		buttonSelected;

						private CS_FadeInOut fadeInOut;

	void Awake()
	{
		fadeInOut = GameObject.Find ("PFB_FadeScreen").GetComponent<CS_FadeInOut>();
	}
		
	void OnMouseUp ()
	{
		//Determines which button you clicked
		switch (button)
		{
		case ButtonType.Continue:
			fadeInOut.EndScene();
			buttonSelected = "UI_LevelSelect";
			break;
		case ButtonType.NewGame:
			//Confirmation Prompt
			//buttonSelected = "UI_LevelMenu";
			break;
		case ButtonType.Options:
			//Options Menu Appears
			Application.LoadLevel("UI_LevelSelect");
			break;
		}
	}


}
