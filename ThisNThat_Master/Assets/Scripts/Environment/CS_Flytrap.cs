using UnityEngine;
using System.Collections;

public class CS_Flytrap : MonoBehaviour 
{
	public float timer = 2.5f;
	public float timerLimit = 2.5f;

	
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
			print ("4");
			cS_CheckPoint_Controller.Die ();
			print ("5");
			timer = timerLimit;
			print ("6");
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
