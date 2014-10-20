using UnityEngine;
using System.Collections;

public class CS_Checkpoints : MonoBehaviour 
{
	public bool isTouched = false;
	public bool isSpecial = false;
	public bool didRed = false;
	public bool didBlue = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag ("Player")) 
		{
			return;
		}

		if (other.gameObject.name == "characterRed") {
						didRed = true;
				}
		if (other.gameObject.name == "characterBlue") {
			didBlue = true;
				}
		if (other.gameObject.name == "rideOnPlayer") {

				}

		if (didRed == true || didBlue == true) {
						isTouched = true;
				}

		
	}
	
	
	
}