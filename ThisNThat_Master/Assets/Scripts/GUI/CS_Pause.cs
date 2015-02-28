using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_Pause : MonoBehaviour 
{

	Canvas canvas;
	bool resumeClick = false;
	private CS_HUD hud;

	void Start () 
	{
		StartCoroutine (PauseCoroutine());
		canvas = GetComponent<Canvas>();
		hud = GameObject.Find ("HUD").GetComponent<CS_HUD>();
		canvas.enabled = false;
	}

	void Update () 
	{

	}

	IEnumerator PauseCoroutine() 
	{
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.Escape) || resumeClick)
			{
				if (Time.timeScale == 0)
				{ Time.timeScale = 1; canvas.enabled = false; hud.collectableImg.enabled = false; resumeClick = false;}
				else
				{ Time.timeScale = 0; canvas.enabled = true; hud.collectableImg.enabled = true;}
			}
			yield return null;
		}
	}

	public void Resume ()
	{
		resumeClick = true;
	}

	public void Quit ()
	{
		Time.timeScale = 1;
		StartCoroutine(QuitLevelDelay());

	}

	IEnumerator QuitLevelDelay()
	{
		yield return new WaitForSeconds(0.75f);
		CS_LoadingScreen.show();
		Application.LoadLevel("UI_LevelSelect");
	}
}
