using UnityEngine;
using System.Collections;

public class EnableOnEnter : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		GetComponent<Moving_Platforms>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Player")
			{
				GetComponent<Moving_Platforms>().enabled = true;
			}
	}

}
