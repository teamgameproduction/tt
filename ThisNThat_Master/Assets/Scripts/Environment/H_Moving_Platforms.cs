using UnityEngine;
using System.Collections;

public class H_Moving_Platforms : MonoBehaviour 
{

	float platformSpeed = 0.05f;
	//public bool isTouched = true;
	
	public Transform hPlatform;
	public Transform hStart;
	public Transform hEnd;

	Vector3 direction;
	Transform destination;

	void Start()
	{
		SetDestination(hStart);
	}
	
	void Update()
	{
		//if (other.gameObject.tag == "Digable")
		{
			//isTouched = false;
				
			hPlatform.rigidbody.MovePosition (hPlatform.position + direction * platformSpeed);
				
			if (Vector3.Distance (hPlatform.position, destination.position) < platformSpeed)
			{
					SetDestination(destination == hStart ? hEnd : hStart); 
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
		direction = (destination.position - hPlatform.position).normalized;

	}

	void OnTriggerEnter(Collider other)
	{

	}
}

	


