using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	public int Level;
	public string[] LevelNames;

	void Start()
	{ 
		Level = 0;
	}

	public void NextLevel()
	{	
		Level += 1;
		if (Level > 3)
			{Level = 0;}
	}

	public void PreviousLevel()
	{	
		Level -= 1;
		if (Level < 0)
			{Level = 3;}
	}

	public void LoadLevel()
	{
		Application.LoadLevel ("" + LevelNames[Level]);
	}

	public void TitleLoad()
	{
		Application.LoadLevel ("UI_LevelSelect");
	}

	public void ForestPlanet()
	{
		Level = 0;
	}

	public void ArcticPlanet()
	{
		Level = 1;
	}

	public void CavePlanet()
	{
		Level = 2;
	}

	public void VolcanoPlanet()
	{
		Level = 3;
	}
}
