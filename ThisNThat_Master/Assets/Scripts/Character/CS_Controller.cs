using UnityEngine;
using System.Collections;

public class CS_Controller : MonoBehaviour 
{
	[HideInInspector]	public Vector3 RedPosition;
	[HideInInspector]	public Vector3 BluePosition;
	[HideInInspector]	public Vector3 RedCameraPosition;
	[HideInInspector]	public Vector3 BlueCameraPosition;
						public float cameraZposition = -08F;
	[HideInInspector]	public Vector3 cameraPosition;

	public bool animationInterupt = false;
	private float redWait;
	private float blueWait;
	public bool  canPullBack =false;
	private bool hasMoved = false;
	private bool switchingToblue = false;
	private bool switchingToRed = false;


	private float maxZposition = -10F;
	private float minZposition = -8F;

						//CHARACTER
	[HideInInspector]	public int 			IsCharacterRed = 1;
	[HideInInspector]	public GameObject 	gmcharacterRed;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	mainCamera;

						//CAMERAS
						//public Camera 		CameraRed;
						//public Camera 		CameraBlue;

						//MOVEMENT VARIABLES
						public float 		Speed = 4.0f;
						public float		ResetSpeed = 4.0f;
						public float 		TogetherSpeed = 6.0f;
						public float		ResetTogetherSpeed = 6.0f;
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
	[HideInInspector]	public  CS_BlueAnimCTRL BlueAnimScript;
	[HideInInspector]	public  CS_RedAnimCTRL RedAnimScript;


	public bool RedIsFacingRight = true;
	public bool BlueIsFacingRight = true;
	
	void Start () 
	{
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		mainCamera = GameObject.Find ("Camera");

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
		if (Input.GetAxis ("Horizontal") > 0.0f) {
			hasMoved = true;
			canPullBack = false;
		}
		if (Input.GetAxis ("Horizontal") < 0.0f) {
			hasMoved = true;
			canPullBack = false;
		}

		if (Input.GetAxis("Horizontal") > 0.0f && cameraZposition > maxZposition){
			cameraZposition = cameraZposition + -0.1F;
		}
		if (Input.GetAxis("Horizontal") < 0.0f && cameraZposition > maxZposition){
			cameraZposition = cameraZposition + -0.1F;
		}
		if (Input.GetAxis("Horizontal") == 0.0f && cameraZposition < minZposition){
			//StartCoroutine ("waitPullBack");
		//	if(canPullBack == true){
				cameraZposition = cameraZposition + 0.005F;
			}

		if (switchingToblue == true && (Input.GetAxis ("Horizontal") >0 || Input.GetAxis ("Horizontal") <0)){
			if (hasMoved == true){
				iTween.MoveTo(mainCamera,(BlueCameraPosition),0f);
				SwitchToBlue ();
				Speed = 4;
				switchingToblue = false;
			}
		}
		if (switchingToRed == true && (Input.GetAxis ("Horizontal") >0 || Input.GetAxis ("Horizontal") <0)){
			if (hasMoved == true){
				iTween.MoveTo(mainCamera,(RedCameraPosition),0f);
				SwitchToRed ();
				Speed = 4;
				switchingToRed = false;
			}
		}

		cameraPosition = mainCamera.transform.position;
		mainCamera.transform.position = new Vector3 (cameraPosition.x, cameraPosition.y, cameraZposition);

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
		if (Input.GetButtonDown("E") && IsCharacterRed == 1)
		{	
			BluePosition = gmcharacterBlue.transform.position;
			BlueCameraPosition = new Vector3 (BluePosition.x, BluePosition.y, cameraPosition.z);
			StartCoroutine("WaitBlue");
			switchingToblue = true;
			iTween.MoveTo(mainCamera,(BlueCameraPosition),1);
		}
//-------------------------------------------------------------------------------------------------------

		//SWITCH CHARACTERS BACK
//-------------------------------------------------------------------------------------------------------
		else if (Input.GetButtonDown("E") && IsCharacterRed == 2)
		{
			RedPosition = gmcharacterRed.transform.position;
			RedCameraPosition = new Vector3 (RedPosition.x, RedPosition.y, cameraPosition.z);
			StartCoroutine("WaitRed");
			switchingToRed = true;
			iTween.MoveTo(mainCamera,(RedCameraPosition),1);
		}

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
			if (Input.GetAxis ("Horizontal") >0 && RedIsFacingRight == false){
				gmcharacterRed.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
				RedIsFacingRight = true;
			}
			if (Input.GetAxis ("Horizontal")<0 && RedIsFacingRight == true){
				gmcharacterRed.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
				RedIsFacingRight = false;
			}
		}
		else if (IsCharacterRed == 2){
			if (Input.GetAxis ("Horizontal") >0 && BlueIsFacingRight == false){
				gmcharacterBlue.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
				BlueIsFacingRight = true;
			}
			if (Input.GetAxis ("Horizontal") <0 && BlueIsFacingRight == true){
				gmcharacterBlue.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
				BlueIsFacingRight = false;
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
	

//-------------------------------------------------------------------------------------------------------
	IEnumerator waitPullBack()
	{
		yield return new WaitForSeconds (3.0F);	
			canPullBack = true;
	}

	//Use this function to switch to Blue
	IEnumerator WaitRed()
	{
		yield return new WaitForSeconds (1.0F);	
			SwitchToRed ();
			Speed = 4;
		if (hasMoved == true){
			yield break;
		} 
				}
	
	IEnumerator WaitBlue()
	{
		yield return new WaitForSeconds (1.0F);
			SwitchToBlue ();
			Speed = 4;
		if (hasMoved == true){
			yield break;
		} 
		}
	public void SwitchToBlue(){

		//Detaches children from the controller
		IsCharacterRed = 2;
		//SwitchCheck = true;

		transform.DetachChildren();
		
		//Attaches character 2 to the controller
		gmcharacterBlue.transform.parent=gameObject.transform;
		//switches camera
		//CameraRed.camera.enabled = false;
		//CameraBlue.camera.enabled = true;
		Speed = ResetSpeed;
	}

//-------------------------------------------------------------------------------------------------------
	//Use this function to switch to Red
	public void SwitchToRed(){
						
		transform.DetachChildren ();
						gmcharacterRed.transform.parent = gameObject.transform;
						//Switches camera
						//CameraBlue.camera.enabled = false;
						//CameraRed.camera.enabled = true;
						IsCharacterRed = 1;

						//Resets Red if he is being carried by Blue
						if (bluePickup.PickedUp == true) {
								BlueFlapForce = BlueFlapForce * 3;
								bluePickup.PickedUpObject.rigidbody.isKinematic = false;
								bluePickup.PickedUp = false;
								gmcharacterBlue.rigidbody.mass = gmcharacterBlue.rigidbody.mass - bluePickup.PickedUpObject.rigidbody.mass;
								BlueFlapForce = BlueFlapRestoreForce;
								bluePickup.PickedUpObject.collider.enabled = true;
								bluePickup.BlueBoxColl.size = new Vector3 (1.0f, 1.5f, 1.0f);
								bluePickup.BlueBoxColl.center = new Vector3 (0, 0, 0);
								Speed = ResetSpeed;
						} else {
								BlueFlapForce = BlueFlapRestoreForce;
						}
		} 
	//Sugar
	//Spice
	//And everything nice
	//But professor Brian accidentally added another ingredient:
	
	//Coroutine X:
	/*IEnumerator CreatePowerpuffGirls(){
		GameObject.Instantiate (Blossom);
		GameObject.Instantiate (Bubbles);
		GameObject.Instantiate (Buttercup);

	}
	*/
}
