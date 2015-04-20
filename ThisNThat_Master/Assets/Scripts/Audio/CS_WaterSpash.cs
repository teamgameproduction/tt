using UnityEngine;
using System.Collections;

public class CS_WaterSpash : MonoBehaviour 
{
	public AudioClip[] spashSND;
	// Use this for initialization
	void Start () 
	{


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		//splash sound when player jumps in water
		//int ss = Random.Range (0, spashSND.Length);
		//AudioSource.PlayClipAtPoint(spashSND[ss], transform.position);
	}
}
