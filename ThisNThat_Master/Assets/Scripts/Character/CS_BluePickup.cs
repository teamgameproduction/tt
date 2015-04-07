using UnityEngine;
using System.Collections;

public class CS_BluePickup : MonoBehaviour //This script allows Blue to pick up Red
{
						public bool PickupRange = false;
						public bool PickedUp = false;
						public GameObject PickedUpObject;

	[HideInInspector]	public CS_Controller controller;
	[HideInInspector]	public CS_FlapReset flapReset;
						public GameObject gmcharacterRed;
						//public GameObject gmcharacterBlue;

						//coordinates for the position of red and blue
	[HideInInspector]	public float CPRy;
	[HideInInspector]	public float CPBx;
	[HideInInspector]	public float CPBy;
	[HideInInspector]	public float CPBz;
						public Vector3 CharPosBlue;
						public float CPByOffset = 1.5f;

						public float BlueCarryingFlapSpeed = 600.0f;
	[HideInInspector]	public BoxCollider BlueBoxColl;

	//Adjust this to position Blue a little higher to be able to attach to red
	public float BlueAttachHeightAdjustment = 1;



	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent<CS_Controller>();
		flapReset = GameObject.Find ("characterBlue").GetComponent<CS_FlapReset>();
		gmcharacterRed = GameObject.Find ("characterRed");
		//gmcharacterBlue = GameObject.Find ("characterBlue");
		BlueBoxColl = gameObject.collider as BoxCollider;
		//CPRy = gmcharacterRed.transform.position.y;
		//CPBy = gmcharacterBlue.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PickedUp == true)
		{
			CPBx = gameObject.transform.position.x;
			CPBy = gameObject.transform.position.y - CPByOffset;
			CPBz = gameObject.transform.position.z;
			CharPosBlue = new Vector3 (CPBx,CPBy,CPBz);
			//gmcharacterRed.transform.position = CharPosBlue;
			PickedUpObject.transform.position = CharPosBlue;
		}
		//CPRy = gmcharacterRed.transform.position.y;
		//CPBy -= CPRy = yDifference;
		//print (yDifference);

		//To Pick Up Red
		if (Input.GetButtonDown ("LS_Click") && PickupRange == true && controller.IsCharacterRed == 2 && PickedUp == false)
		{
			//gmcharacterRed.transform.parent=gameObject.transform;
			if(flapReset.Grounded == true){
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + BlueAttachHeightAdjustment, gameObject.transform.position.z);
			}
			PickedUp = true;
			gameObject.rigidbody.mass = gameObject.rigidbody.mass + PickedUpObject.rigidbody.mass;
			PickedUpObject.rigidbody.isKinematic = true;
			controller.BlueFlapForce = BlueCarryingFlapSpeed;
			PickedUpObject.collider.enabled = false;
			BlueBoxColl.size = new Vector3(1,4,1);
			BlueBoxColl.center = new Vector3(0.0f,-1.5f,0.0f);
			controller.Speed = controller.TogetherSpeed;
		}
		//To Get Picked Up By Blue
		else if (Input.GetButtonDown ("LS_Click") && PickupRange == true && controller.IsCharacterRed == 1 && PickedUp == false) {

			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + BlueAttachHeightAdjustment, gameObject.transform.position.z);
			controller.SwitchToBlue();
			PickedUp = true;
			gameObject.rigidbody.mass = gameObject.rigidbody.mass + PickedUpObject.rigidbody.mass;
			PickedUpObject.rigidbody.isKinematic = true;
			controller.BlueFlapForce = BlueCarryingFlapSpeed;
			PickedUpObject.collider.enabled = false;
			BlueBoxColl.size = new Vector3(1,4,1);
			BlueBoxColl.center = new Vector3(0.0f,-1.5f,0.0f);
			controller.Speed = controller.TogetherSpeed;
				}

		//To Drop Red like it's hot
		else if (Input.GetButtonDown ("LS_Click") && PickedUp == true)
		{
			gmcharacterRed.rigidbody.isKinematic = false;
			PickedUp = false;
			gameObject.rigidbody.mass = gameObject.rigidbody.mass - PickedUpObject.rigidbody.mass;
			controller.BlueFlapForce = controller.BlueFlapRestoreForce;
			gmcharacterRed.collider.enabled = true;
			BlueBoxColl.size = new Vector3(1.0f,1.5f,1.0f);
			BlueBoxColl.center = new Vector3(0,0,0);
			controller.Speed = controller.ResetSpeed;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "PickUpable") 
		{
			PickupRange = true;
			PickedUpObject = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "PickUpable") 
		{
			PickupRange = false;
		}
	}
}	
