using UnityEngine;
using System.Collections;

public class CS_BlueAnimCTRL : MonoBehaviour {
	
	public Animator animator;
	public Animator animatorR;
	public CS_FlapReset flapReset;
	public  CS_Controller 	controller;
    public  CS_BluePickup bluePickup;
	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
		animatorR = GameObject.Find ("Red_Animation_All_Final").GetComponent<Animator>();
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.IsCharacterRed == 2 && bluePickup.PickedUp == false) {
						if (Input.GetKey ("d") && flapReset.Grounded == true || Input.GetKey ("a") && flapReset.Grounded == true) {
								animator.SetBool ("Running", true);
						} else if (Input.GetKey ("d") && Input.GetKeyDown ("space") || Input.GetKey ("a") && Input.GetKeyDown ("space")) {
								animator.SetBool ("Jump", true);
						} else {
								animator.SetBool ("Running", false);

						}
		
						if (Input.GetKeyUp ("space") || Input.GetKeyDown ("space")) {
								animator.SetBool ("Jump", true);
						} else {
								animator.SetBool ("Jump", false);
						}	
				}
		if (controller.IsCharacterRed == 2 && bluePickup.PickedUp == true) {
			if(flapReset.Grounded == false){
				animatorR.SetBool ("Running", false);

			}
			if (Input.GetKeyUp ("space") || Input.GetKeyDown ("space")) {
				animator.SetBool ("Jump", true);

			} else {
				animator.SetBool ("Jump", false);
			}	
			}
	}
}
