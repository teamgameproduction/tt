using UnityEngine;
using System.Collections;

public class V_Moving_Platform : MonoBehaviour 
{
	
	float platformSpeed = 0.05f;
	public bool isTouched;
	
	public Transform vPlatform;
	public Transform vStart;
	public Transform vEnd;
	
	Vector3 direction;
	Transform destination;
	
	void Start()
	{
		SetDestination(vStart);
		isTouched = true;
	}
	
	void Update()
	{
		{
			vPlatform.rigidbody.MovePosition (vPlatform.position + direction * platformSpeed);
			
			if (Vector3.Distance (vPlatform.position, destination.position) < platformSpeed)
			{
				SetDestination(destination == vStart ? vEnd : vStart); 
			}

		}
	
	}

	
	void SetDestination(Transform dest)
	{
		destination = dest;
		direction = (destination.position - vPlatform.position).normalized;
		
	}
	
	void OnTriggerEnter(Collider other)
	{
	
	}
}




