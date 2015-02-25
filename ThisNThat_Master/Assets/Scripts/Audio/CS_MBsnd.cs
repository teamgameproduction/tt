using UnityEngine;
using System.Collections;

public class CS_MB : MonoBehaviour 
{

	//SOUND FOR MUSHROOM BOUNCE
	public AudioClip[] MB_SND;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		//bouncy sound when bouce on mushroom in cave level
		int bb = Random.Range (0, MB_SND.Length);
		AudioSource.PlayClipAtPoint(MB_SND[bb], transform.position);
	}
}
