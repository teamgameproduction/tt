using UnityEngine;
using System.Collections;

public class CS_BlockBlue : MonoBehaviour {
	
	[HideInInspector]	public GameObject gmcharacterRed;
	[HideInInspector]	public GameObject gmcharacterBlue; 
	private CS_Controller ControllerScript;
	// Use this for initialization
	void Start () {

		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
		ControllerScript = GetComponent<CS_Controller>();

	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		ControllerScript.SwitchToRed();

		if (other.gameObject == gmcharacterRed) {
						gameObject.collider.enabled = false;
				}
		else if (other.gameObject == gmcharacterBlue) 
		{
			gameObject.collider.enabled = true;
		}
	}
}
