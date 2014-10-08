using UnityEngine;
using System.Collections;

public class CS_BlockBlue : MonoBehaviour {
	
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

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == gmcharacterBlue) 
		{
			gameObject.collider.enabled = true;
		}

		else if (other.gameObject == gmcharacterRed) 
		{
			gameObject.collider.enabled = false;
		}
	}
}
