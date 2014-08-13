using UnityEngine;
using System.Collections;

public class CS_LevelSelect : MonoBehaviour 
{
	
	public enum LevelType {Cave, Arctic, Forest, Volcano}
	public LevelType Level;

	public GameObject World;
	public float rotationSpeed = 0.5f;
	public static Quaternion worldRotation;
		
	void Start ()
	{
		CS_LevelSelect.worldRotation = Quaternion.identity;
	}

	void Update ()
	{
		if(World.transform.eulerAngles != CS_LevelSelect.worldRotation.eulerAngles)
		{
			World.transform.eulerAngles = Vector3.Slerp(World.transform.eulerAngles, CS_LevelSelect.worldRotation.eulerAngles, rotationSpeed * Time.deltaTime);
		}
	}

	void OnMouseUp ()
	{
		switch (Level)
		{
		case LevelType.Cave:
			CS_LevelSelect.worldRotation = Quaternion.identity;
		break;
		case LevelType.Arctic:
			//World.transform.Rotate(new Vector3(0,0,90));
			CS_LevelSelect.worldRotation.eulerAngles = new Vector3(0f,0f,90f);
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
