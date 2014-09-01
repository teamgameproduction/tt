using UnityEngine;
using System.Collections;

public class CS_Controller : MonoBehaviour 
{
						//CHARACTER
	[HideInInspector]	public int 			IsCharacterRed = 1;
	[HideInInspector]	public GameObject 	gmcharacterRed;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	private bool 		PlayedOnce = false ;

						//CAMERAS
						public Camera 		CameraRed;
						public Camera 		CameraBlue;

						//MOVEMENT VARIABLES
						public float 		Speed = 4.0f;
	[HideInInspector]	private float 		MoveDirection;

						//ICE
						public float 		IceAcceleration = 1.0f;
	[HideInInspector]	public bool 		RedOnSlip;
	[HideInInspector]	public bool 		BlueOnSlip;


						//JUMPING
						public float 		BlueFlapForce = 300.0f;
						public float 		RedFlapForce = 400.0f;
						public int 			BlueMaxFlaps = 3;
						public int 			RedMaxFlaps = 1;
	[HideInInspector]	public int 			BlueFlaps = 0;
	[HideInInspector]	public int 			RedFlaps = 0;
	[HideInInspector]	public float 		BlueFlapRestoreForce = 300.0f;
						
						//Slow Movement
						public float    	slowMove;
						public bool			touch = false;

						

						//PICKUP
	[HideInInspector]	public  CS_BluePickup bluePickup;


	public bool RedIsFacingRight = true;
	public bool BlueIsFacingRight = true;

	void Start () 
	{
		//Finds the two characters and the controller and labels them
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");

		//Reference the  CS_BluePickup script
		bluePickup = GameObject.Find ("characterBlue").GetComponent< CS_BluePickup>();

		//Set max number of flaps
		BlueFlaps = BlueMaxFlaps;
		RedFlaps = RedMaxFlaps;

		//Set Red as default character
		gmcharacterRed.transform.parent = gameObject.transform;
		IsCharacterRed = 1;

		slowMove = 2.0f;
	}
	
	void Update () 
	{
		//MOVEMENT
//-------------------------------------------------------------------------------------------------------
		if (RedOnSlip == true && IsCharacterRed == 1 || BlueOnSlip == true && IsCharacterRed == 2)
		{
			if (Input.GetAxis("Horizontal") > 0.0f)
			{
				LerpPos();
				this.transform.Translate((MoveDirection * Speed) * Time.deltaTime, 0, 0);
			}
			else if (Input.GetAxis("Horizontal") < 0.0f)
			{
				LerpNeg();
				this.transform.Translate((MoveDirection * Speed) * Time.deltaTime, 0, 0);
			}
			else if (Input.GetAxis("Horizontal") == 0 && Speed > 0.0f)
			{
				LerpNull();
				this.transform.Translate((MoveDirection * Speed) * Time.deltaTime, 0, 0);
			}
		}
		else
		{
			if (Input.GetAxis("Horizontal") != 0.0f && IsCharacterRed != 3)
			{
				MoveDirection = Input.GetAxisRaw("Horizontal");
				this.transform.Translate((MoveDirection * Speed) * Time.deltaTime, 0, 0);
			}
		}
//-------------------------------------------------------------------------------------------------------

		//SWITCH CHARACTERS
//-------------------------------------------------------------------------------------------------------
		if (Input.GetKeyDown("e") && IsCharacterRed == 1){

			//Detaches children from the controller
			transform.DetachChildren();

			//Attaches character 2 to the controller
			gmcharacterBlue.transform.parent=gameObject.transform;
			IsCharacterRed = 2;
			//PlayedOnce is needed to stop the script from reattaching to character 1
			PlayedOnce = true;
			//switches camera
			//CameraRed.camera.enabled = false;
			//CameraBlue.camera.enabled = true;
		}
//-------------------------------------------------------------------------------------------------------

		//ATTACH CHARACTERS
//-------------------------------------------------------------------------------------------------------
		if (Input.GetKeyDown("e") && IsCharacterRed == 2 && PlayedOnce == false)
		{
			transform.DetachChildren();

			gmcharacterRed.transform.parent=gameObject.transform;
			IsCharacterRed = 1;

			//Switches camera
			//CameraBlue.camera.enabled = false;
			//CameraRed.camera.enabled = true;

			//Resets Red if he is being carried by Blue
			if (bluePickup.PickedUp == true)
			{
				BlueFlapForce = BlueFlapForce * 3;
				bluePickup.PickedUpObject.rigidbody.isKinematic = false;
				bluePickup.PickedUp = false;
				gmcharacterBlue.rigidbody.mass = gmcharacterBlue.rigidbody.mass - bluePickup.PickedUpObject.rigidbody.mass;
				BlueFlapForce = BlueFlapRestoreForce;
				bluePickup.PickedUpObject.collider.enabled = true;
				bluePickup.BlueBoxColl.size = new Vector3(1.0f,1.5f,1.0f);
				bluePickup.BlueBoxColl.center = new Vector3(0,0,0);
			}
			else
			{
				BlueFlapForce = BlueFlapRestoreForce;
			}
		}

		PlayedOnce = false;
//-------------------------------------------------------------------------------------------------------

		//JUMP
//-------------------------------------------------------------------------------------------------------
		if (Input.GetButtonDown ("Jump")) 
		{
			if (IsCharacterRed == 1 && RedFlaps > 0)
			{
				RedFlap();
				RedFlaps --;
			}
			else if (IsCharacterRed == 2 && BlueFlaps > 0) 
			{
				BlueFlap ();
				BlueFlaps --;
			}
		}
//-------------------------------------------------------------------------------------------------------

		//Turn the character
		if (IsCharacterRed == 1){
			if (Input.GetKeyDown ("d") && RedIsFacingRight == false){
				gmcharacterRed.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
				RedIsFacingRight = true;
			}
			if (Input.GetKeyDown ("a") && RedIsFacingRight == true){
				gmcharacterRed.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
				RedIsFacingRight = false;
			}
		}
	}

		//ICE MOVEMENT
//-------------------------------------------------------------------------------------------------------
	void LerpPos()
	{
		MoveDirection = Mathf.Lerp (MoveDirection, 1.0f, IceAcceleration * Time.deltaTime);
	}
	void LerpNeg()
	{
		MoveDirection = Mathf.Lerp (MoveDirection, -1.0f, IceAcceleration * Time.deltaTime);
	}
	void LerpNull()
	{
		MoveDirection = Mathf.Lerp (MoveDirection, 0.0f, Time.deltaTime);
	}
//-------------------------------------------------------------------------------------------------------


		//JUMPING
//-------------------------------------------------------------------------------------------------------
	void RedFlap()
	{
		gmcharacterRed.rigidbody.AddForce (Vector3.up * RedFlapForce);
	}
	void BlueFlap()
	{
		gmcharacterBlue.rigidbody.AddForce (Vector3.up * BlueFlapForce);
	}


//-------------------------------------------------------------------------------------------------------

	//Slow Movement
//-------------------------------------------------------------------------------------------------------
	void OnTriggerEnter(Collider other)
	{


	}

//-------------------------------------------------------------------------------------------------------

	//Sugar
	//Spice
	//And everything nice
	//But professor Brian accidentally added another ingredient:
	
	//Coroutine Ex:
	/*IEnumerator RedKinematicCoroutine(){
		yield return new WaitForSeconds(0.1f);
		gmcharacterRed.rigidbody.isKinematic = false;
	}*/

}
