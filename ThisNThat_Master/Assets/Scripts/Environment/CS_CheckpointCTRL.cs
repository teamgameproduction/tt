using UnityEngine;
using System.Collections;

public class CS_CheckpointCTRL : MonoBehaviour {
	
	public Vector3 StartingPosition;

	public Vector3 CurrentCheckpointRed;
	public Vector3 CurrentCheckpointBlue;

	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;

	// Use this for initialization
	void Start () {
	
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");

		CurrentCheckpointRed = StartingPosition;
		CurrentCheckpointBlue = StartingPosition - new Vector3(2,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator DieRed(){
		print ("printing1");
		yield return new WaitForSeconds (1);
		gmcharacterRed.transform.position = CurrentCheckpointRed;
	}

	public IEnumerator DieBlue(){
		print ("printing2");
		yield return new WaitForSeconds (1);
		gmcharacterBlue.transform.position = CurrentCheckpointBlue;
	}
	
}
