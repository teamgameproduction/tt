using UnityEngine;
using System.Collections;

public class CS_Checkpoint_Controller : MonoBehaviour 
{
	public GameObject[] checkPointArray;
	public GameObject[] checkPointArray2;
	public static int currentCheckPoint		=0;
	public static int currentSpot			=0;
	public static Vector3 startPosition;
	public Vector3 spawnPos;
	public bool spawn = false;
	public CS_Checkpoints cS_Checkpoints ;
	public GameObject 	gmcharacterBlue;
	public GameObject 	gmcharacterRed;
	public int arrayLength = 0;
	public string s0;
	public string s1;
	public string cp1;
	public string cp2;
	public string cp3;
	public string cp4;
	public string cp5;
	public string cp6;
	int r;


	int x = 0;
	
	// Use this for initialization
	void Start () 
		
	{
		checkPointArray = GameObject.FindGameObjectsWithTag ("CheckPoint");
		checkPointArray2 = GameObject.FindGameObjectsWithTag ("CheckPoint");
		startPosition = transform.position;
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
		arrayLength = checkPointArray.Length;
	

		for(int i = 0; i < checkPointArray.Length; i++)
		{
			for(int j = 0; j < checkPointArray.Length; j++)
			{
				r=i+1;
			s0 = r + "";
			//print (s0);
			s1 = checkPointArray[j] + "";
			//print (s1);
			//print (s1.EndsWith(s0));
				//print(s0 + s1[11]);
				if(s0 == s1[11] + "")
			{
				checkPointArray2[i] = checkPointArray[j];
				//print (checkPointArray2[i]);
			}
			}


		}

		cp1 = checkPointArray2 [0]+ "";
		cp2 = checkPointArray2 [1]+ "";
		cp3 = checkPointArray2 [2]+ "";
		cp4 = checkPointArray2 [3]+ "";
		cp5 = checkPointArray2 [4]+ "";
		cp6 = checkPointArray2 [5]+ "";
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
		//print (checkPointArray [x - 1].transform.position);
		while (spawn == false && x != arrayLength) {
			
			cS_Checkpoints = checkPointArray[x].GetComponent<CS_Checkpoints>();
			
			
			x++;
			spawn = cS_Checkpoints.isTouched;
			
			
		}
		//Application.LoadLevel(Application.loadedLevel);
		spawnPos = checkPointArray[x-1].transform.position;
		gmcharacterBlue.transform.position = new Vector3(spawnPos.x, spawnPos.y + 1, spawnPos.z);
		gmcharacterRed.transform.position = new Vector3(spawnPos.x - 2, spawnPos.y + 1, spawnPos.z);
		x = 0;
		spawn = false;

		//print (checkPointArray [x - 1].transform.position);
		
		
	}
}
