using UnityEngine;
using System.Collections;

public class CS_Checkpoint_Controller : MonoBehaviour 
{
	public GameObject[] checkPointArray;
	public static int currentCheckPoint		=0;
	public static int currentSpot			=0;
	public static Vector3 startPosition;
	public Vector3 spawnPos;
	public bool spawn = false;
	public CS_Checkpoints cS_Checkpoints ;
	public GameObject 	gmcharacterBlue;
	public GameObject 	gmcharacterRed;
	public int arrayLength = 0;
	int x = 0;
	
	// Use this for initialization
	void Start () 
		
	{
		checkPointArray = GameObject.FindGameObjectsWithTag ("CheckPoint");
		startPosition = transform.position;
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
		arrayLength = checkPointArray.Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.C)) {
			Die ();
		}
	}
	
	public void Die()
	{
		while (spawn == false && x != arrayLength) {
			
			cS_Checkpoints = checkPointArray[x].GetComponent<CS_Checkpoints>();
			
			
			x++;
			spawn = cS_Checkpoints.isTouched;
			
			
		}
		Application.LoadLevel(Application.loadedLevel);
		spawnPos = checkPointArray[x-1].transform.position;
		gmcharacterBlue.transform.position = new Vector3(spawnPos.x, spawnPos.y + 1, spawnPos.z);
		gmcharacterRed.transform.position = new Vector3(spawnPos.x - 2, spawnPos.y + 1, spawnPos.z);
		x = 0;
		spawn = false;
		
		
	}
}
