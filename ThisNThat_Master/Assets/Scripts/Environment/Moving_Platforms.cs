using UnityEngine;
using System.Collections;

public class Moving_Platforms : MonoBehaviour 
{

	float platformSpeed = 0.05f;
	//public bool isTouched = true;
	
	public Transform platform;
	public Transform start;
	public Transform end;

	Vector3 direction;
	Transform destination;

	void Start()
	{
		SetDestination(start);
	}
	
	void Update()
	{
		//if (other.gameObject.tag == "Digable")
		{
			//isTouched = false;
				
			platform.rigidbody.MovePosition (platform.position + direction * platformSpeed);
				
			if (Vector3.Distance (platform.position, destination.position) < platformSpeed)
			{
					SetDestination(destination == start ? end : start); 
			}
		}
			
		//if (other.gameObject.tag == "Digable")
		//{
			//isTouched = true;
			//SetDestination(destination == hStart ? hEnd : hStart); 
				
		//}
	}
	

	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position - platform.position).normalized;

	}

	void OnTriggerEnter(Collider other)
	{

	}
}

	


