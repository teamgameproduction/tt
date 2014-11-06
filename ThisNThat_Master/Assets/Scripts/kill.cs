using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	public CS_CheckpointCTRL checkPointCTRL;
	public GameObject TriggeringPlayer;

	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;
	// Use this for initialization
	void Start () {

		checkPointCTRL = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL>();
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other)
	{
		//if(!other.CompareTag("Player"))
		//{
		//	return;
	//	}
		if (other.gameObject.tag == "Player") {


			TriggeringPlayer = other.gameObject;

						if (other.gameObject.tag == "Player") {
							
							if(TriggeringPlayer == gmcharacterRed){
					print ("DieRed1");
								checkPointCTRL.DieRed();
					print ("DieRed2");
							}
							
							else {
								checkPointCTRL.DieBlue();
							}
							
						}
				}
	}
}
