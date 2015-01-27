using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CS_LevelTitle : MonoBehaviour 
{
	Text Title;
	private CS_LevelSelect Level;
	public string[] BiomeTitles;

	// Use this for initialization
	void Start () 
	{
		Title = GetComponent<Text>();
		Level = GameObject.Find ("GameState").GetComponent<CS_LevelSelect>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Title.text = "" + BiomeTitles[Level.Level] + " Planet";
	}
}
