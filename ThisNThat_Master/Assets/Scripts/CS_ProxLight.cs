using UnityEngine;
using System.Collections;

public class CS_ProxLight : MonoBehaviour {
	public bool touch = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(touch == true)
			gameObject.light.intensity = 6;

		else
		gameObject.light.intensity = 0;
	
	}

	void OnTriggerEnter (Collider other)
	{
		if(!other.CompareTag("Player"))
		{
			return;
		}
		touch = true;

		
	}

	void OnTriggerExit (Collider other)
	{
		if(!other.CompareTag("Player"))
		{
			return;
		}
		
		touch = false;
		
	}
}
