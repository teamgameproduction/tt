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
	int x = 0;
	
	// Use this for initialization
	void Start () 
		
	{
		checkPointArray = GameObject.FindGameObjectsWithTag ("CheckPoint");
		startPosition = transform.position;
		gmcharacterBlue = GameObject.Find ("characterBlue");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.C)) {
			Die ();
		}
	}
	
	void Die()
	{
		while (spawn == false && x != 10) {
			
			cS_Checkpoints = checkPointArray[x].GetComponent<CS_Checkpoints>();
			
			
			x++;
			spawn = cS_Checkpoints.isTouched;
			
			
		}
		spawnPos = checkPointArray[x].transform.position;
		gmcharacterBlue.transform.position = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z);
		x = 0;
		spawn = false;
		
		
	}
}
