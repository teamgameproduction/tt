using UnityEngine;
using System.Collections;

public class CS_Checkpoint : MonoBehaviour {

	[HideInInspector]	public CS_CheckpointCTRL checkpointCTRL;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;

	public GameObject TriggeringPlayer;

	public bool SetCheckpointForRed = true;
	public bool SetCheckpointForBlue = true;

	// Use this for initialization
	void Start () {
	
		checkpointCTRL = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL> ();
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {

			TriggeringPlayer = other.gameObject;

			if(TriggeringPlayer == gmcharacterRed && SetCheckpointForRed == true){
				checkpointCTRL.CurrentCheckpointRed = this.transform.position;

				if(SetCheckpointForBlue == true){
					checkpointCTRL.CurrentCheckpointBlue = this.transform.position;
				}
			}

			else if(TriggeringPlayer == gmcharacterBlue && SetCheckpointForBlue == true){
				checkpointCTRL.CurrentCheckpointBlue = this.transform.position;

				if(SetCheckpointForRed == true){
					checkpointCTRL.CurrentCheckpointRed = this.transform.position;
				}
			}

				}
	}
}
