using UnityEngine;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	//Button Variables
	[HideInInspector]	public GameObject 	subButton_01;
	[HideInInspector]	public GameObject 	subButton_02;
	[HideInInspector]	public GameObject 	subButton_03;
	[HideInInspector]	public Vector3 		offset_01;
	[HideInInspector]	public Vector3 		offset_02;
	[HideInInspector]	public Vector3 		offset_03;
						public enum 		LevelType {Null, Cave, Arctic, Forest, Volcano, Sub1, Sub2, Sub3}
						public LevelType 	Level;
						public bool			buttonsAreUp = false;			
						public float		subButtonRiseSpeed = 0.8f;
	//World Menu Variables
	[HideInInspector]	public GameObject 	World;
						public float 		rotationSpeed = 2.0f;
						public static Quaternion worldRotation;
						public static float	currentBiome; //replace with strings for biome names?
						public static float 		currentLevel; //replace with strings for level names?
		
	void Start ()
	{
		//Initialize the static variable on start
		CS_LevelSelect.worldRotation = Quaternion.identity;
		CS_LevelSelect.currentBiome = 1f;
		CS_LevelSelect.currentBiome = 1f;

		//Find and assign the world
		World = GameObject.Find ("World");

		//Find and assign the SubButtons
		subButton_01 = GameObject.Find ("SubButton_01");
		subButton_02 = GameObject.Find ("SubButton_02");
		subButton_03 = GameObject.Find ("SubButton_03");

		//Initialize the button offsets
		offset_01 = new Vector3(-6.5f,2.5f,0.0f);
		offset_02 = new Vector3(-6.5f,3.75f,0.0f);
		offset_03 = new Vector3(-6.5f,5.0f,0.0f);
	}

	void Update ()
	{
		//Rotate the world sprite while the rotation is not equal to the desired rotation
		if(World.transform.eulerAngles != CS_LevelSelect.worldRotation.eulerAngles)
		{
			buttonsAreUp = false;
			World.transform.eulerAngles = Vector3.Slerp(World.transform.eulerAngles, CS_LevelSelect.worldRotation.eulerAngles, rotationSpeed * Time.deltaTime);
		}
	
		//Bring up the level buttons while the position is not equal to the desired rotation
		if(subButton_01.transform.position != offset_01 && subButton_02.transform.position != offset_02 && subButton_03.transform.position != offset_03 && buttonsAreUp == true)
		{
			SlideButtonsUp();
		}
		if (buttonsAreUp == false)
		{
			SlideButtonsDown();
		}
	}

	void OnMouseUp ()
	{
		//Determines which button you clicked and adjusts the desired rotation accordingly
		switch (Level)
		{
		case LevelType.Cave:
			CS_LevelSelect.worldRotation = Quaternion.identity;
			currentBiome = 1f;
			break;
		case LevelType.Arctic:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,90);
			currentBiome = 2f;
			break;
		case LevelType.Forest:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,180);
			currentBiome = 3f;
			break;
		case LevelType.Volcano:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,270);
			currentBiome = 4f;
			break;
		case LevelType.Sub1:
			CS_LevelSelect.currentLevel = currentBiome + 0.1f;
			print ("I'm loading" + CS_LevelSelect.currentLevel);
			break;
		case LevelType.Sub2:
			CS_LevelSelect.currentLevel = currentBiome + 0.2f;
			print ("I'm loading" + CS_LevelSelect.currentLevel);
			break;
		case LevelType.Sub3:
			CS_LevelSelect.currentLevel = currentBiome + 0.3f;
			print ("I'm loading" + CS_LevelSelect.currentLevel);
			break;
		}
	}

	void SlideButtonsUp ()
	{
		subButton_01.transform.position = Vector3.Slerp(subButton_01.transform.position, offset_01, subButtonRiseSpeed * Time.deltaTime);
		subButton_02.transform.position = Vector3.Slerp(subButton_02.transform.position, offset_02, subButtonRiseSpeed * Time.deltaTime);
		subButton_03.transform.position = Vector3.Slerp(subButton_03.transform.position, offset_03, subButtonRiseSpeed * Time.deltaTime);
	}
	void SlideButtonsDown ()
	{
		subButton_01.transform.position = Vector3.Slerp(subButton_01.transform.position, new Vector3(-6.5f,-1f,0f), subButtonRiseSpeed * Time.deltaTime);
		subButton_02.transform.position = Vector3.Slerp(subButton_02.transform.position, new Vector3(-6.5f,-1f,0f), subButtonRiseSpeed * Time.deltaTime);
		subButton_03.transform.position = Vector3.Slerp(subButton_03.transform.position, new Vector3(-6.5f,-1f,0f), subButtonRiseSpeed * Time.deltaTime);
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{		
		yield return new WaitForSeconds(0.1f);
		buttonsAreUp = true;
	}
}
