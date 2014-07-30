using UnityEngine;
using System.Collections;

public class CS_WeightSense : MonoBehaviour 
{
						public float 		TotalMass = 0.0f;
						public float 		TriggeringMass;
						public float 		PushedDown = 2.4f;
						public float 		PushedReset = 2.7f;

	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (TotalMass < 3)
		{
			//gameObject.transform.position = new Vector3 (gameObject.transform.position.x, PushedReset, gameObject.transform.position.z);
		}
		else
		{
			//gameObject.transform.position = new Vector3 (gameObject.transform.position.x, PushedDown, gameObject.transform.position.z);
		}
	
	}

	void OnCollisionEnter(Collision other)
	{
		TriggeringMass = other.gameObject.rigidbody.mass;
		TotalMass = TotalMass + TriggeringMass;
	}

	void OnCollisionExit(Collision other)
	{
		TriggeringMass = other.gameObject.rigidbody.mass;
		TotalMass = TotalMass - TriggeringMass;
	}
}

