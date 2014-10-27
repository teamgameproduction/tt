using UnityEngine;
using System.Collections;

public class CS_Flytrap : MonoBehaviour 
{
	public float timer;
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
		timer = timer + Time.deltaTime;

		if (timer >= 0.5f) 
		{
			timer = timerLimit;
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		touch = true;

	if (timer <= 0.5f)
		{
			cS_CheckPoint_Controller.Die ();
		}

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
