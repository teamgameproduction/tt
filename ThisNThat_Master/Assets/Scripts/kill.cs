using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	public CS_CheckpointCTRL checkPointCTRL;
	public CS_BluePickup bluePickup;
	public GameObject TriggeringPlayer;

	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;
	// Use this for initialization
	void Start () {

		checkPointCTRL = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent<CS_BluePickup>();
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
			
			if(bluePickup.PickedUp == true){
				checkPointCTRL.StopCoroutine("DieBlue");
				checkPointCTRL.StartCoroutine("DieBlue");
			}
			
			else if(TriggeringPlayer == gmcharacterRed){
				
				//checkPointCTRL.DieRed();
				checkPointCTRL.StopCoroutine("DieRed");
				checkPointCTRL.StartCoroutine("DieRed");
				print ("startkillingred");
				
			}
			
			else {
				//checkPointCTRL.DieBlue();
				checkPointCTRL.StopCoroutine("DieBlue");
				checkPointCTRL.StartCoroutine("DieBlue");
				print ("startkillingblue");
			}


			//Destroy (gameObject);
						
				}

	}

			
		

}
