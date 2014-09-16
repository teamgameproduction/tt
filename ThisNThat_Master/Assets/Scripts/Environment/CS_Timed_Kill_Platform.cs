using UnityEngine;
using System.Collections;

public class CS_Timed_Kill_Platform : MonoBehaviour 
{
	public float timer;
	public float timerLimit = 5.5f;

	public bool touch;
	public CS_Checkpoint_Controller cS_CheckPoint_Controller;

	void Start ()
	{
		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_Checkpoint_Controller>();
		touch = false;
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
		if (timer >= 3.0f) 
		{
			renderer.material.color = new Color(0,1,0);
		}
		else if (timer < 3.0f && timer > 1.0f)
		{
			renderer.material.color = new Color(1,1,0);
		}
		else if (timer <= 1.0f)
		{
			renderer.material.color = new Color(1,0,0);
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
