using UnityEngine;
using System.Collections;

public class CS_Flytrap : MonoBehaviour 
{
	public float timer = 2.0f;
	public float timerLimit = 2.0f;

	
	public bool isTouch;
	public CS_CheckpointCTRL cS_CheckPoint_Controller;
	
	void Start ()
	{
		cS_CheckPoint_Controller = GameObject.Find ("GameState").GetComponent<CS_CheckpointCTRL>();
		isTouch = false;
		renderer.material.color = new Color(0,1,0);
	}
	
	void Update () 
	{
		if (isTouch == true) 
		{
			timer = timer - Time.deltaTime;
		}
		if (timer <= 0.5f && isTouch ==true)
		{
			//print ("4");
			//checkPointCTRL.StartCoroutine("DieBlue");
			//checkPointCTRL.
			cS_CheckPoint_Controller.StartCoroutine("DieRed");
			cS_CheckPoint_Controller.StartCoroutine("DieBlue");

			//checkPointCTRL.StartCoroutine("DieRed");
			cS_CheckPoint_Controller.DieRed ();
			//print ("5");
			timer = timerLimit;
			renderer.material.color = new Color(0,1,0);
			//print ("6");
		}

		if (timer <= 2.0f)
		{
			renderer.material.color = new Color(1,1,0);
		}
		if (timer <= 1.0f)
		{
			renderer.material.color = new Color(1,0,0);
		}

	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			isTouch = true;
			return;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
			{
				isTouch = false;
				timer = timerLimit;
				renderer.material.color = new Color(0,1,0);
			}
		
	}
	
}
