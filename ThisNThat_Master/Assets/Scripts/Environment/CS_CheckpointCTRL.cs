using UnityEngine;
using System.Collections;

public class CS_CheckpointCTRL : MonoBehaviour {

	[HideInInspector]	public CS_Controller controller;
	[HideInInspector]	public  CS_BluePickup 	bluePickup;

	public Vector3 StartingPosition;

	public Vector3 CurrentCheckpointRed;
	public Vector3 CurrentCheckpointBlue;

	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;

	// Use this for initialization
	void Start () {
	
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent< CS_BluePickup>();

		CurrentCheckpointRed = StartingPosition;
		CurrentCheckpointBlue = StartingPosition - new Vector3(2,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator DieRed(){
		yield return new WaitForSeconds (1);
		gmcharacterRed.transform.position = CurrentCheckpointRed;
		controller.Speed = controller.ResetSpeed;
	}

	public IEnumerator DieBlue(){
		yield return new WaitForSeconds (1);
		gmcharacterBlue.transform.position = CurrentCheckpointBlue;
		if (bluePickup.PickedUp == false) {
						controller.Speed = controller.ResetSpeed;
				} else {
						controller.Speed = controller.ResetTogetherSpeed;
				}
	}
	
}
