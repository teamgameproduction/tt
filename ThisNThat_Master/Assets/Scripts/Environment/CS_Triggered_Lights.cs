using UnityEngine;
using System.Collections;

public class CS_Triggered_Lights : MonoBehaviour 
{
	public bool touch;
	public bool lightInteract;
	
	
	
	// Use this for initialization
	void Start () 
	{
		touch = false;
		lightInteract = false;
		gameObject.light.intensity = 0;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if (Input.GetButtonDown ("Y") && gameObject.light.intensity == 0 && lightInteract == true && touch==true)
		{
			gameObject.light.intensity = 6;
			lightInteract = false;
			StartCoroutine(WaitforLights());
			print ("Lights On");
		}
		
		/*if (Input.GetKeyUp (KeyCode.Q) && gameObject.light.intensity == 6 && lightInteract == true)
		{ 
			gameObject.light.intensity = 0;
			lightInteract = false;
			StartCoroutine(WaitforLights());
			print ("Lights Off");
		}*/
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")

		touch = true;
		lightInteract = true;
		print ("I Work Here!");
			
		{
			return;
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			lightInteract = false;
			touch = false;
		}
	}
	
	IEnumerator WaitforLights()
	{
		
		yield return new WaitForSeconds(0.1f);
		lightInteract = true;
	}
	
}

