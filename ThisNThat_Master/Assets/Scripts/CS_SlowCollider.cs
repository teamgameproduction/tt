using UnityEngine;
using System.Collections;

public class CS_SlowCollider : MonoBehaviour 
{
	public  CS_Controller 	controller;
	public  CS_Controller 	Speed;
	public bool				touch;
	public	CS_Controller	BlueFlapForce;
	public	CS_Controller	BlueFlaps;
	
	// Use this for initialization
	void Start () 
	{
		touch = false;
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{ 

			touch = true;
			controller.Speed = 2.0f;
			controller.BlueFlaps = 1;
			controller.BlueFlapForce = 150;
			print ("Go Faster!!!");
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			controller.Speed = 4.0f;
			controller.BlueFlaps = 2;
			controller.BlueFlapForce = 300;
			touch = false;
			print ("I Can Run Again!!!!!");
		}
	}
}
