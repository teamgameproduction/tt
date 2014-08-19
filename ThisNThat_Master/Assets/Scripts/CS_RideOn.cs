using UnityEngine;
using System.Collections;

public class CS_RideOn : MonoBehaviour {
	public bool touch = false;
	public bool isGround  =true;
	public int players = 0;
	public int jumpForce = 500;
	public int jump = 1;
	public GameObject 	controller;
	public GameObject rideOnPlayer;
	public CS_Controller cS_Controller;
	public CS_FlapReset cS_FlapReset;
	public Camera 		CameraRed;
	public Camera 		CameraBlue;
	public Camera 		CameraRide;
	// Use this for initialization
	void Start () {
	
		controller = GameObject.Find ("CharacterController");
		rideOnPlayer= GameObject.Find ("RideOnPlayer");
		cS_Controller = GameObject.Find ("CharacterController").GetComponent<CS_Controller>();
		cS_FlapReset = GameObject.Find ("RideOnPlayer").GetComponent<CS_FlapReset>();

	}
	
	// Update is called once per frame
	void Update () {

		if (cS_Controller.IsCharacterRed == 3) {
						rideOnPlayer.transform.Translate (5 * Time.deltaTime, 0, 0);
				}

		isGround = cS_FlapReset.Grounded;

		if (isGround == true) {
			jump = 1;		
		}

		if (Input.GetKeyDown (KeyCode.R) && players == 2 && touch == true) {

			controller.transform.DetachChildren();
			rideOnPlayer.transform.parent = controller.transform;
			CameraRide.camera.enabled = true;
			CameraRed.camera.enabled = false;
			CameraBlue.camera.enabled = false; 
			cS_Controller.IsCharacterRed = 3; 



				}
		if (Input.GetButtonDown ("Jump") && cS_Controller.IsCharacterRed == 3 && jump < 2) {
						rideOnPlayer.rigidbody.AddForce (Vector3.up * jumpForce);
						jump++;
				}

	
	}







	void OnTriggerEnter (Collider other)
	{
		if(!other.CompareTag("Player"))
		{
			return;
		}
		touch = true;
		players++;
		
		
	}
	
	void OnTriggerExit (Collider other)
	{
		if(!other.CompareTag("Player"))
		{
			return;
		}
		
		touch = false;
		players--;
		
	}
}
