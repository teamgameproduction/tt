using UnityEngine;
using System.Collections;

public class CS_Digable : MonoBehaviour 
{
						public bool 		IsRedTouching = false;
						public  CS_Controller 	controller;

	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("f") && IsRedTouching == true && controller.IsCharacterRed == true)
		{
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//Debug.Log ("I dig that");
			IsRedTouching = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			IsRedTouching = false;
		}
	}

}
