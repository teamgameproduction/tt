using UnityEngine;
using System.Collections;

public class CS_Checkpoint : MonoBehaviour {

	[HideInInspector]	public CS_CheckpointCTRL checkpointCTRL;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;

	public GameObject TriggeringPlayer;

	public bool SetCheckpointForRed = true;
	public bool SetCheckpointForBlue = true;
	private Animator CheckPointAnim;


	// Use this for initialization
	void Start () {
	
		checkpointCTRL = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL> ();
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
		CheckPointAnim = gameObject.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {

		CheckPointAnim.SetBool("Spawn", true);

		if (other.gameObject.tag == "Player") {

			TriggeringPlayer = other.gameObject;

			if(TriggeringPlayer == gmcharacterRed && SetCheckpointForRed == true){
				checkpointCTRL.CurrentCheckpointRed = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z -1.5f);

				if(SetCheckpointForBlue == true){

					checkpointCTRL.CurrentCheckpointBlue = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z -1.5f);
				}
			}

			else if(TriggeringPlayer == gmcharacterBlue && SetCheckpointForBlue == true){
				checkpointCTRL.CurrentCheckpointBlue = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z -1.5f);

				if(SetCheckpointForRed == true){
					checkpointCTRL.CurrentCheckpointRed = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z -1.5f);
				}
			}

				}
	}
}
