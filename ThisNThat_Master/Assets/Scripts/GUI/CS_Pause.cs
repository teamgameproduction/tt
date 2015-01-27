using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_Pause : MonoBehaviour 
{

	void Start () 
	{
		StartCoroutine (PauseCoroutine());
	}

	void Update () 
	{

	}

	IEnumerator PauseCoroutine() 
	{
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (Time.timeScale == 0)
					{ Time.timeScale = 1;}
				else{ Time.timeScale = 0;}
			}
			yield return null;
		}
	}
}
