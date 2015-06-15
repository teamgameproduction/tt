using UnityEngine;
using System.Collections;

public class CS_RedAnimCTRL : MonoBehaviour {

	public Animator animator;
	public CS_FlapReset flapReset;
	public  CS_Controller controller;
	public  CS_BluePickup bluePickup;
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator>();
		flapReset = GameObject.Find ("characterBlue").GetComponent<CS_FlapReset>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent<CS_BluePickup>();
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("right shift")|| Input.GetKeyDown ("left shift")) {
						animator.SetBool ("Smashing", true);
				} else {
						animator.SetBool ("Smashing", false);
				}
		if (controller.IsCharacterRed == 1 && bluePickup.PickedUp == false){
		if (Input.GetKey ("d") || Input.GetKey ("a")){
			animator.SetBool ("Running", true);
		}

		else {
			animator.SetBool ("Running", false);
		}

		if (Input.GetKeyDown ("space")){
			
				animator.SetBool ("Jump", true);
		}

		else{
			animator.SetBool ("Jump", false);
		}		}
		else if (controller.IsCharacterRed == 2 && bluePickup.PickedUp == true){
			if (Input.GetKey ("d") && flapReset.Grounded == true|| Input.GetKey ("a") && flapReset.Grounded == true){
				animator.SetBool ("Running", true);
			}
			else{
				animator.SetBool ("Running", false);
			}
			if (Input.GetKeyDown ("space")){
			}else{

			}

		}
	}
}
