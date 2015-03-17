using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CS_Results : MonoBehaviour 
{
	private Canvas canvas;
	private Text planetText;
	private Animator fade;
	public Camera resultCam;

	public GameObject[] resultCritters;
	private CS_HUD hud;

	void Start () 
	{
		fade = GameObject.Find("FaderCanvas").GetComponent<Animator>();
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		resultCritters = GameObject.FindGameObjectsWithTag("ResultCritter");
		hud = GameObject.Find("HUD").GetComponent<CS_HUD>();

		#if UNITY_EDITOR
		planetText = GameObject.Find("Planet Text").GetComponent<Text>();
		if(EditorApplication.currentScene.Contains("Forest"))
		{planetText.text = "Forest - 1";}
		else if (EditorApplication.currentScene.Contains("Arctic"))
		{planetText.text = "Arctic - 1";}
		else if (EditorApplication.currentScene.Contains("Underground"))
		{planetText.text = "Cave - 1";}
		else if (EditorApplication.currentScene.Contains("Volcano"))
		{planetText.text = "Volcano - 1";}
		#endif

		resultCam.enabled = false;

		for (int i = resultCritters.Length - 1; i >= 0; i--)
		{	resultCritters[i].SetActive(false);	}
	}

	void Update () 
	{
		
	}

	public void Replay()
	{
		fade.Play ("Anim_FadeOut");
		StartCoroutine(LoadLevelDelay(0));
	}

	public void LevelSelect()
	{
		fade.Play ("Anim_FadeOut");
		StartCoroutine(LoadLevelDelay(1));
	}

	public void GameWon()
	{
		fade.Play ("Anim_FadeOut");
		PopulateCritters();
		StartCoroutine(CameraSwapDelay());
	}

	void PopulateCritters()
	{
		for (int i = (hud.collectableCount - 1); i >= 0; i--)
		{	resultCritters[i].SetActive(true);	}
	}

	IEnumerator CameraSwapDelay()
	{
		yield return new WaitForSeconds(1f);
		resultCam.enabled = true;
		fade.Play ("Anim_FadeIn");
		yield return new WaitForSeconds(0.75f);
		canvas.enabled = true;
	}

	IEnumerator LoadLevelDelay(int levelToLoad)
	{
		yield return new WaitForSeconds(0.75f);
		CS_LoadingScreen.show();
		if(levelToLoad == 1)
		{Application.LoadLevel("UI_LevelSelect");}
		else if(levelToLoad == 0)
		{Application.LoadLevel(Application.loadedLevel);}
	}
}
