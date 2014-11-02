using UnityEngine;
using System.Collections;

public class CS_Flytrap : MonoBehaviour 
{
	public float timer = 2.0f;
	public float timerLimit = 2.0f;

	
	public bool touch;
	public CS_Checkpoint_Controller cS_CheckPoint_Controller;
	
	void Start ()
	{
		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_Checkpoint_Controller>();
		touch = false;
	}
	
	void Update () 
	{
		if (touch == true) 
		{
			timer = timer - Time.deltaTime;
		}
		if (timer < 0.5f && touch ==true)
		{
			//print ("4");
			cS_CheckPoint_Controller.Die ();
			//print ("5");
			timer = timerLimit;
			//print ("6");
		}

		if (timer >= 2.0f) 
		{
			renderer.material.color = new Color(0,1,0);
		}
		else if (timer < 1.5f && timer > 1.0f)
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
				timer = timerLimit;
			}
		
	}
	
}
