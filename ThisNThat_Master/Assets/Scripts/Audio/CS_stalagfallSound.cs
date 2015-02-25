using UnityEngine;
using System.Collections;

public class CS_stalagfallSound : MonoBehaviour
{

	public AudioClip[]	stalagDropSnd;
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
	}*/

	void OnTriggerEnter()
	{
		int sf = Random.Range (0, stalagDropSnd.Length);
		AudioSource.PlayClipAtPoint(stalagDropSnd[sf], transform.position);
	}
}
