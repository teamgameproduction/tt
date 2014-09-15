using UnityEngine;
using System.Collections;

public class CS_Timed_Kill_Platform : MonoBehaviour 
{
	public float timer;
	public float timerLimit = 5.5f;

	public bool touch = false;
	public CS_Checkpoint_Controller cS_CheckPoint_Controller;

	void Start ()
	{
		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_Checkpoint_Controller>();

		timer = timerLimit;
	
	}
	
	void Update () 
	{
		timer = timer - Time.deltaTime;

			if (touch == true && timer <= 0.5f) 
			{
				cS_CheckPoint_Controller.Die ();
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
