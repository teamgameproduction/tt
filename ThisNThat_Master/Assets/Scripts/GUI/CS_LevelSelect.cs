using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	public int Level;
	public string[] LevelNames;
	public GameObject menuCanvas;
	public Animator planetSwapper;

	void Start()
	{ 
		Level = 0;
		planetSwapper = menuCanvas.GetComponent<Animator>();
	}

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

	public void LoadLevel()
	{
		StartCoroutine(LoadLevelDelay());
	}

	IEnumerator LoadLevelDelay()
	{
		yield return new WaitForSeconds(0.75f);
		CS_LoadingScreen.show();
		Application.LoadLevel ("" + LevelNames[Level]);
	}

	public void TitleLoad()
	{
		Application.LoadLevel ("UI_LevelSelect");
	}

	public void ForestPlanet()	
	{	
		Level = 0;
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new  Vector3 (0,0,0);
	}
	public void ArcticPlanet()	
	{
		Level = 1;
		planetSwapper.Play("Anim_PlanetSwap");
		//planetInfo.animation.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,90,0);
	}
	public void CavePlanet()	
	{
		Level = 2;
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,180,0);
	}
	public void VolcanoPlanet()	
	{
		Level = 3;
		planetSwapper.Play("Anim_PlanetSwap");
		CS_Planet.endRotation.eulerAngles = new Vector3 (0,270,0);
	}
}
