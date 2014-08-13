using UnityEngine;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	//Button Variables
	public enum LevelType {Null, Cave, Arctic, Forest, Volcano}
	public LevelType Level;

	//World Menu Variables
	public GameObject World;
	public float rotationSpeed = 0.5f;
	public static Quaternion worldRotation;
		
	void Start ()
	{
		//Initialize the static variable on start
		CS_LevelSelect.worldRotation = Quaternion.identity;
	}

	void Update ()
	{
		//Perform the rotation while the plane's rotation is not equal to the desired rotation
		if(World.transform.eulerAngles != CS_LevelSelect.worldRotation.eulerAngles)
		{
			World.transform.eulerAngles = Vector3.Slerp(World.transform.eulerAngles, CS_LevelSelect.worldRotation.eulerAngles, rotationSpeed * Time.deltaTime);
		}
	}

	void OnMouseUp ()
	{
		//Determines which button you clicked and adjusts the desired rotation accordingly
		switch (Level)
		{
		case LevelType.Cave:
			CS_LevelSelect.worldRotation = Quaternion.identity;
			break;
		case LevelType.Arctic:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,90);
			break;
		case LevelType.Forest:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,180);
			break;
		case LevelType.Volcano:
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0,0,270);
			break;
		}
	}
}
