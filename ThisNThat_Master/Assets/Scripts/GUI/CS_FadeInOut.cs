using UnityEngine;
using System.Collections;

public class CS_FadeInOut : MonoBehaviour 
{
	public float 		fadeSpeed = 1.5f;
	private bool 		sceneStarting = true;
	private bool		sceneEnding = false;

	private CS_MainMenu mainMenu;

	void Awake ()
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}
	
	void Update()
	{
		if(sceneStarting)
		{
			StartScene();
		}

		if(sceneEnding)
		{
			EndScene();
		}
	}

	void FadeToClear()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void FadeToBlack()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
	
	void StartScene()
	{
		FadeToClear();
		
		if(guiTexture.color.a <= 0.05f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;
			sceneStarting = false;
		}
	}
	
	public void EndScene()
	{
		guiTexture.enabled = true;
		sceneEnding = true;
		FadeToBlack();
		
		if(guiTexture.color.a >= 0.95f)
		{
			guiTexture.color = Color.black;
			sceneEnding = false;
		}
	}
}
