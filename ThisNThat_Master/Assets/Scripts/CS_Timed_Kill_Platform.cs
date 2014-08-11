using UnityEngine;
using System.Collections;

public class CS_Timed_Kill_Platform : MonoBehaviour 
{
	public float timer;
	public float timerLimit = 5.0f;

	void Start ()
	{
		timer = timerLimit;
	}
	
	void Update () 
	{
		timer = timer - Time.deltaTime;

		{
			if(timer <= 0.0f)
			{
			timer = timerLimit;
			}
		}
			
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			if (timer <= 0.0f) 
			{
				GetComponent<CS_Kill>();
			}	
				{
					print ("You're Dead!");
				}
		}
	}
}
