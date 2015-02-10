using UnityEngine;
using System.Collections;

public class CS_Camera : MonoBehaviour {

	[HideInInspector]	public GameObject 	gmcharacterRed;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public CS_Controller controller;
	[HideInInspector]	public Vector3 RedPosition;
	[HideInInspector]	public Vector3 BluePosition;
	[HideInInspector]	public  CS_Controller cameraZposition;

						private  float ZPosition =-10; 
	// Use this for initialization
	void Start () {
	
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();

	}
	
	// Update is called once per frame
	void Update () {

		//ZPosition = cameraZposition.cameraZposition;

		if (controller.IsCharacterRed == 1){
			RedPosition = gmcharacterRed.transform.position;
			gameObject.transform.position = new Vector3 (RedPosition.x, RedPosition.y, ZPosition);
		}

		else if (controller.IsCharacterRed == 2){
			BluePosition = gmcharacterBlue.transform.position;
			gameObject.transform.position = new Vector3 (BluePosition.x, BluePosition.y, ZPosition);
		}
	}
}
