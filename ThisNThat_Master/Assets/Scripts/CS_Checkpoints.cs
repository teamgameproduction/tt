using UnityEngine;
using System.Collections;

public class CS_Checkpoints : MonoBehaviour 
{
	public bool isTouched = false;
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag ("Player")) 
		{
			return;
		}
		
		isTouched = true;
		
	}
	
	
	
}