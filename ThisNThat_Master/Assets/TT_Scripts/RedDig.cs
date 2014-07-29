using UnityEngine;
using System.Collections;

public class RedDig : MonoBehaviour 
{
						public Controller 	controller;
						public GameObject 	TriggeringDirt;
	
	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("f") && controller.IsCharacterRed == true)
		{
			Destroy (TriggeringDirt);
		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Digable") 
		{
			Debug.Log ("I dig that");
			TriggeringDirt = other.gameObject;
		}
	}
}
