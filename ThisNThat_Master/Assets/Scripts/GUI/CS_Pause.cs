using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_Pause : MonoBehaviour 
{

	Canvas canvas;
	bool resumeClick = false;

	void Start () 
	{
		StartCoroutine (PauseCoroutine());
		canvas = GetComponent<Canvas>();
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
					{ Time.timeScale = 1; canvas.enabled = false; resumeClick = false;}
				else
					{ Time.timeScale = 0; canvas.enabled = true;}
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
		Application.LoadLevel("UI_LevelSelect");
	}
}
