using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_LevelDescription : MonoBehaviour 
{
	Text Description;
	private CS_LevelSelect Level;
	[TextArea(3,10)]
	public string[] PlanetDescriptions;

	// Use this for initialization
	void Start () 
	{
		Description = GetComponent<Text>();
		Level = GameObject.Find ("GameState").GetComponent<CS_LevelSelect>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Description.text = "" + PlanetDescriptions[Level.Level];
	}
}
