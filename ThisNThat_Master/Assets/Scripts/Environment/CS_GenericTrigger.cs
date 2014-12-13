using UnityEngine;
using System.Collections;

public class CS_GenericTrigger : MonoBehaviour 
{

	public bool collision = false;
	public string CollisionType;
	public bool IfTriggerExitTogglesOff;
	public float timerDuration;
	public bool entered= false;
	
	void Start () 
	{	
	}
	
	void Update () 
	{
		if (timerDuration == 0)
		{}
		else if (collision && timerDuration > 0f)
		{
			timerDuration -= Time.deltaTime;
		}
		else if (collision && timerDuration <= 0f)
		{
			collision = false;
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == CollisionType && entered==false) 
		{
			collision = true;
			entered=true;
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
