using UnityEngine;
using System.Collections;

public class CS_RenderProx : MonoBehaviour 
{
						public bool 		HasTriggered = false;
						public float 		playerproximity;
						public float 		xpos;
						public float 		triggerproximity  = 20.0f;
						public float 		triggerproximityexiting  = -20.0f;
						public float 		CharacterXpos;

						public  CS_Controller 	controller;
						public GameObject 	gmcharacterRed;
						public GameObject 	gmcharacterBlue;

	// Use this for initialization
	void Start () 
	{
		renderer.enabled = false;
		controller = GameObject.Find ("CharacterController").GetComponent< CS_Controller>();
		gmcharacterRed = GameObject.Find ("characterRed");
		gmcharacterBlue = GameObject.Find ("characterBlue");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (controller.IsCharacterRed == 1)
		{
			CharacterXpos = gmcharacterRed.transform.position.x;
		}
		else 
		{
			CharacterXpos= gmcharacterBlue.transform.position.x;
		}
	
		xpos = gameObject.transform.position.x;
		playerproximity = CharacterXpos - xpos;


		if ((playerproximity <= triggerproximity))//&& HasTriggered == false)
		{
			HasTriggered = true;
			renderer.enabled = true;
		}
		else
		{
			HasTriggered = false;
			renderer.enabled = false;
		}


		if ((triggerproximityexiting >= playerproximity))
		{
			HasTriggered = false;
			renderer.enabled = false;
		}
	}
}
