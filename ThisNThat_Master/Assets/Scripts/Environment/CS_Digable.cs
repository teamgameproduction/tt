using UnityEngine;
using System.Collections;

public class CS_Digable : MonoBehaviour 
{
	public  bool 			IsRedTouching = false;
	//public 	AudioClip[] 		crushSound;
	[HideInInspector]	public  CS_Controller 	controller;
	[HideInInspector]	public  CS_BluePickup 	bluePickup;
	
	
	// Use this for initialization
	void Start () 
	{
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		bluePickup = GameObject.Find ("characterBlue").GetComponent< CS_BluePickup>();
		//crushSound = GameObject.Find ("object_destroy").GetComponent<AudioClip>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown ("right shift") || Input.GetKeyDown ("left shift") || Input.GetAxis ("Right_Trigger") >0) {
			if (IsRedTouching == true && controller.IsCharacterRed == 1 || IsRedTouching == true && bluePickup.PickedUp == true) {
				//int c = Random.Range (0, crushSound.Length);
				//AudioSource.PlayClipAtPoint(crushSound[c], transform.position);		
				gameObject.SetActive (false);
			}
		}
	}
	
	/*void Awake()
	{
		if (crushSound == null) 
		{
			crushSound = GameObject.Find ("object_destroy").GetComponent<AudioSource>();
		}

		}*/
		

	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "characterRed") 
		{
			//Debug.Log ("I dig that");
			IsRedTouching = true;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "characterRed") 
		{
			IsRedTouching = false;
		}
	}
	
}


