using UnityEngine;
using System.Collections;

public class CS_EnviroMovement : MonoBehaviour {

	//GameObject and Trigger Variables
	public CS_GenericTrigger TriggerBool;
	public GameObject TriggerVolume;

	//Used to designate which object tag will effect the collision
	public string CollisionType;

	//Bools to designate type of movement
	public bool MovementXYZ;
	public bool RotationXYZ;
	public bool Oscillating;
	public bool OscillatingVertical;
	public bool DestroyOnCollision;

	public bool UseTimer;
	public bool TimerExpired;
	public float MoveTimer;
	//[HideInInspector]	public bool ObjectMoving = false;
	//[HideInInspector]	public bool ObjectOscillating = false;
	
	//Oscillation Movement
	public int OscillatingSpeed = 0;
	public int OscillatingResetSpeed = 2;
	//public float MovementTimer = 0.0f;
	public bool HasStarted = false;
	public bool RightFinished = false;
	[HideInInspector]public float RightTimer = 0.0f;
	[HideInInspector]public float LeftTimer = 0.0f;
	[HideInInspector]public bool RightMovement = false;
	[HideInInspector]public bool LeftMovement = false;
	public float MoveDistance = 2.0f;

	//Vector 3 Movement
	public Vector3 MoveDirection;

	public Vector3 RotateDirection;




	
	
	// Use this for initialization
	void Start () {

		TriggerBool = TriggerVolume.GetComponent<CS_GenericTrigger>();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (UseTimer == true) {
			if (TriggerBool.collision == true && MoveTimer > -1){
			MoveTimer -= Time.deltaTime;
			}
			if (MoveTimer < 0){
				TimerExpired = true;
			}
				}

		//Movement in the xyz directions
		if (TriggerBool.collision == true && MovementXYZ == true && TimerExpired == false){
			MoveXYZ();
		}

		if (TriggerBool.collision == true && RotationXYZ == true && TimerExpired == false){
			RotateXYZ();
		}

		//Everything Below  in the Update is for Oscillation
		if (TriggerBool.collision == false){
			OscillatingSpeed = 0;
		}
		else {
			OscillatingSpeed = OscillatingResetSpeed;
		}

		if (TriggerBool.collision == true && Oscillating == true && TimerExpired == false) {
			if (HasStarted == false){
				OscillatingSpeed = OscillatingResetSpeed;
				HasStarted = true;
				//print ("it keeps starting");
				
			}
		}
		if (RightFinished == false){
			if (HasStarted == true) {
				RightTimer += Time.deltaTime;
				//Vector3 x = transform.right * Time.deltaTime * HorizontalSpeed;
				//transform.Translate (x);
				RightMovement = true;
			}
		}
		
		if (RightTimer > MoveDistance) {
			RightFinished = true;
			//LeftTimer += Time.deltaTime;
			RightTimer = 0;
			RightMovement = false;
			LeftMovement = true;
			
			
		}
		
		else if (LeftTimer > MoveDistance) {
			//RightTimer += Time.deltaTime;
			LeftTimer = 0;
			LeftMovement = false;
			RightMovement = true;
			
		}
		
		if (RightMovement == true) {
			OscRight();
		}
		
		else if (LeftMovement == true) {
			OscLeft();
		}
		
		
		/*if (HorizontalSpeed == 2) {
			MovementTimer += Time.deltaTime;
			print ("third one worked");
		
		}

		if (HorizontalSpeed == -2) {
			MovementTimer -= Time.deltaTime;
			print ("fourth one worked");
		}*/
		
		
		//Vector3 x = transform.right * Time.deltaTime * HorizontalSpeed;
		//transform.Translate (x);
		
	}

	//Functions for Oscillating movement
	void OscRight(){
		if (OscillatingVertical == false){
			Vector3 x = transform.right * Time.deltaTime * OscillatingSpeed;
			transform.Translate (x);
			RightTimer += Time.deltaTime;
		}
		else {
			Vector3 y = transform.up * Time.deltaTime * OscillatingSpeed;
			transform.Translate (y);
			RightTimer += Time.deltaTime;
		}
	}

	void OscLeft(){
		if (OscillatingVertical == false){
			Vector3 x = transform.right * Time.deltaTime * OscillatingSpeed;
			transform.Translate (-x);
			LeftTimer += Time.deltaTime;
		}
		else{
			Vector3 y = transform.up * Time.deltaTime * OscillatingSpeed;
			transform.Translate (-y);
			LeftTimer += Time.deltaTime;
		}
	}
	//Function to move on the xyz axis
	void MoveXYZ(){
		this.transform.Translate (MoveDirection.x * Time.deltaTime,MoveDirection.y * Time.deltaTime, MoveDirection.z * Time.deltaTime);
	}

	void RotateXYZ(){
		transform.Rotate(RotateDirection.x * Time.deltaTime,RotateDirection.y * Time.deltaTime,RotateDirection.z * Time.deltaTime);
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == CollisionType) 
		{
			Destroy (gameObject);
			
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == CollisionType) 
		{
			Destroy (gameObject);
			
		}
	}
	
}

