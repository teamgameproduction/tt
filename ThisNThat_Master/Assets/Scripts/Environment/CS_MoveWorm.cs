using UnityEngine;
using System.Collections;

public class CS_MoveWorm : MonoBehaviour {
	
	public bool collision = false;
//	public string CollisionType;
	public bool IfTriggerExitTogglesOff;
	public float timerDuration;
	public GameObject wormy;
	public bool MovementXYZ;
	private bool enteredcollision;
	public KeyCode button;

	public Vector3 MoveDirection;

	void Start () 
	{	
	}
	
	void Update () 
	{
		if (timerDuration == 0)
		{}
		else if (collision && timerDuration > 0f)
		{
			timerDuration -= Time.deltaTime;
		}
		else if (collision && timerDuration <= 0f)
		{
			collision = false;
		}

		if(collision==true && MovementXYZ==true)
		{
			MoveXYZ();
		}

		if(enteredcollision)
		{if(Input.GetButtonDown ("Y") || Input.GetKeyDown ("right shift") || Input.GetKeyDown ("left shift") || Input.GetAxis ("Right_Trigger") >0)
		{
			collision=true;
		}
		}
	//	else
	//	{
	//		keypressed=false;
	//	}

	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			enteredcollision = true;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player" && IfTriggerExitTogglesOff == true) 
		{
			collision = false;
		}
	}

	void MoveXYZ(){
		wormy.transform.Translate (MoveDirection.x,MoveDirection.y, MoveDirection.z);
		Rigidbody Spike = wormy.GetComponent <Rigidbody> ();
		Spike.isKinematic = false;
	}
}
