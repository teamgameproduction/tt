using UnityEngine;
using System.Collections;

public class CS_BlueAnimCTRL : MonoBehaviour {
	
	public Animator animator;
	public CS_FlapReset flapReset;
	public  CS_Controller 	controller;
	[HideInInspector]	public  CS_BluePickup bluePickup;
	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
		flapReset = GameObject.Find ("characterBlue").GetComponent< CS_FlapReset>();
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.IsCharacterRed == 2){
		if (Input.GetKey ("d") && flapReset.Grounded == true || Input.GetKey ("a") && flapReset.Grounded == true){
			animator.SetBool ("Running", true);
		}
		
		else {
			animator.SetBool ("Running", false);
		}
		
		if (Input.GetKeyDown ("space")){
			animator.SetBool ("Jump", true);
		}
		
		else if (flapReset.Grounded == true){
		animator.SetBool ("Jump", false);
			animator.SetBool ("Falling", false);
		}	
		}
	}
}
