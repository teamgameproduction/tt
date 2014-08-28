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
		buttonSelected = null;
	}

	void Update()
	{
		if (fadeInOut.guiTexture.color.a >= 0.95f && buttonSelected != null)
		{Application.LoadLevel("" + buttonSelected);}
	}
		
	void OnMouseUp ()
	{
		//Determines which button you clicked
		if (fadeInOut.guiTexture.color == Color.clear || fadeInOut.guiTexture.color == Color.black)
		{
			switch (button)
			{
			case ButtonType.Continue:
				fadeInOut.EndScene();
				buttonSelected = "UI_LevelSelect";
				break;
			case ButtonType.NewGame:
				//Confirmation Prompt
				buttonSelected = "UI_LevelMenu";
				break;
			case ButtonType.Options:
				//Options Menu Appears
				break;
			}
		}
	}


}
