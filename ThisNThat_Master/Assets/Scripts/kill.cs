using UnityEngine;
using System.Collections;

public class kill : MonoBehaviour {
	public CS_CheckpointCTRL checkPointCTRL;
	public CS_BluePickup bluePickup;
	public CS_Controller controller;
	public GameObject TriggeringPlayer;
	public Animator animatorR;
	public Animator animatorB;


	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;
	// Use this for initialization
	void Start () {

		checkPointCTRL = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent<CS_BluePickup>();
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");

		animatorR = GameObject.Find ("Master_AnimationFile_002").GetComponent <Animator> ();
		animatorB = GameObject.Find ("blue_animationTest_3").GetComponent <Animator> ();
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
				//checkPointCTRL.StopCoroutine("DieBlue");
				checkPointCTRL.StartCoroutine("DieBlue");
				controller.Speed = 0;
				animatorB.SetBool ("Death", true);
			}
			
			else if(TriggeringPlayer == gmcharacterRed){
				
				//checkPointCTRL.DieRed();
				//checkPointCTRL.StopCoroutine("DieRed");
				checkPointCTRL.StartCoroutine("DieRed");
				controller.Speed = 0;
				animatorR.SetBool ("Death", true);
				
			}
			
			else {
				//checkPointCTRL.DieBlue();
				//checkPointCTRL.StopCoroutine("DieBlue");
				checkPointCTRL.StartCoroutine("DieBlue");
				controller.Speed = 0;
				animatorB.SetBool ("Death", false);
				animatorR.SetBool ("Death", false);
			}


			//Destroy (gameObject);
						
				}

	}

			
		

}
