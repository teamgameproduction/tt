using UnityEngine;
using System.Collections;

public class CS_Timed_Kill_Platform : MonoBehaviour 
{
	public float timer;
	public float timerLimit = 5.5f;

	public bool touch;

	void Start ()
	{
		timer = timerLimit;
		touch = false;
	}
	
	void Update () 
	{
		timer = timer - Time.deltaTime;




			if (touch == true && timer <= 0.5f) 
			{
				GetComponent<CS_Kill>();
				
				
				print ("You're Dead!");
			}

		{
			if(timer <= 0.5f)
			{
				timer = timerLimit;
			}
		}
	}
			

	
	void OnTriggerEnter (Collider other)
	{
		touch = true;
	if(!other.CompareTag("Player"))
		{
			return;
		}

	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			touch = false;
		}

	}

}
