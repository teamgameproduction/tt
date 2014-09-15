using UnityEngine;
using System.Collections;

public class Winning_Moving_Platform : MonoBehaviour 
{
	
	float platformSpeed = 0.05f;
	public bool isTouched = true;
	
	public Transform vPlatform;
	public Transform vStart;
	public Transform vEnd;
	
	Vector3 direction;
	Transform destination;
	
	void Start()
	{
		SetDestination(vStart);
	}
	
	void Update()
	{
		//if (other.gameObject.tag == "Digable")
		{
			//isTouched = false;
			
			vPlatform.rigidbody.MovePosition (vPlatform.position + direction * platformSpeed);
			
			if (Vector3.Distance (vPlatform.position, destination.position) < platformSpeed)
			{ 
				SetDestination(destination == vStart ? vEnd : vStart); 
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
		direction = (destination.position - vPlatform.position).normalized;
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		
	}
}
