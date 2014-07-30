using UnityEngine;
using System.Collections;

public class CS_GenericTrigger : MonoBehaviour {

	public bool collision = false;
	public string CollisionType;
	public bool IfTriggerExitTogglesOff;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == CollisionType) 
		{
			collision = true;
			
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == CollisionType && IfTriggerExitTogglesOff == true) 
		{
			collision = false;
			
		}
	}
}
