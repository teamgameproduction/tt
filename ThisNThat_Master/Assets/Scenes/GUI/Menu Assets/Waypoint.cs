using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour 
{

	public Transform referenceLocation;
	
	void Update () 
	{
		transform.LookAt (referenceLocation);
	}
}
