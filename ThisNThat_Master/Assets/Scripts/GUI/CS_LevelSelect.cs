using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	public int Level;
	public string[] LevelNames;
	public GameObject menuCanvas;
	public Sprite[] moodPaint;
	[HideInInspector]public Image levelPaneImage;
	[HideInInspector]public Animator planetSwapper;

	//Set the level to 0 (forest) and get all necessary components
	//----------------------------------------------------------------------------------------------------
	void Start()
	{ 
		Level = 0;
		levelPaneImage = GameObject.Find ("LevelFrame_img").GetComponent<Image>();
		planetSwapper = menuCanvas.GetComponent<Animator>();
	}
	//----------------------------------------------------------------------------------------------------

	//When the right arrow button is clicked, set the current planet to the next in line
	//----------------------------------------------------------------------------------------------------
	public void NextLevel()
	{	
		Level += 1;
		if (Level > 3)	{Level = 0;}

		switch (Level)
		{
		case 0:
			ForestPlanet();
			break;
		case 1:
			ArcticPlanet();
			break;
		case 2:
			CavePlanet();				
			break;
		case 3:
			VolcanoPlanet();
			break;
		default:
			break;
		}
	}
	//----------------------------------------------------------------------------------------------------

	////When the left arrow button is clicked, set the current planet to the previous in line
	//----------------------------------------------------------------------------------------------------
	public void PreviousLevel()
	{	
		Level -= 1;
		if (Level < 0)	{Level = 3;}

		switch (Level)
		{
		case 0:
			ForestPlanet();
			break;
		case 1:
			ArcticPlanet();
			break;
		case 2:
			CavePlanet();				
			break;
		case 3:
			VolcanoPlanet();
			break;
		default:
			break;
		}
	}
	//----------------------------------------------------------------------------------------------------

	//This function gets called when the level button is clicked
	//----------------------------------------------------------------------------------------------------
	public void LoadLevel()
	{
		StartCoroutine(LoadLevelDelay());
	}
	//----------------------------------------------------------------------------------------------------

	//This coroutine ensures that all the animations have time to finish before loading the level
	//----------------------------------------------------------------------------------------------------
	IEnumerator LoadLevelDelay()
	{
		yield return new WaitForSeconds(0.75f);
		CS_LoadingScreen.show();
		Application.LoadLevel ("" + LevelNames[Level]);
	}
	//----------------------------------------------------------------------------------------------------

	//This function is called from the splash screen, it loads the level select menu
	//----------------------------------------------------------------------------------------------------
	public void TitleLoad()
	{
		Application.LoadLevel ("UI_LevelSelect");
	}
	//----------------------------------------------------------------------------------------------------

	//Adjust the Planet title, mood paint,  position, and play the planet swap animation on the level pane
	//One function is chosen depending on which planet is selected
	//----------------------------------------------------------------------------------------------------
	public void ForestPlanet()	
	{	
		Level = 0;
		levelPaneImage.sprite = moodPaint[Level];
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new  Vector3 (0,0,0);
	}
	public void ArcticPlanet()	
	{
		Level = 1;
		levelPaneImage.sprite = moodPaint[Level];
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,90,0);
	}
	public void CavePlanet()	
	{
		Level = 2;
		levelPaneImage.sprite = moodPaint[Level];
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,180,0);
	}
	public void VolcanoPlanet()	
	{
		Level = 3;
		levelPaneImage.sprite = moodPaint[Level];
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,270,0);
	}
	//----------------------------------------------------------------------------------------------------
}
