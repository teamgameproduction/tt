using UnityEngine;
using System.Collections;

public class CS_Pushable : MonoBehaviour {

	[HideInInspector]	public GameObject gmcharacterRed;
	[HideInInspector]	public GameObject gmcharacterBlue;
	
	// Use this for initialization
	void Start () {
		
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other)
	{
		
		if (other.gameObject == gmcharacterBlue) 
		{
			gameObject.rigidbody.isKinematic = true;
		}
		
		else 
		{
			gameObject.rigidbody.isKinematic = false;
		}
	}

	void OnCollisionExit(Collision other)
	{
		
		if (other.gameObject == gmcharacterBlue) 
		{
			gameObject.rigidbody.isKinematic = false;
		}
	}
}
