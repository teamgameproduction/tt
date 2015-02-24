using UnityEngine;
using System.Collections;

public class CS_collect_Audio : MonoBehaviour {
	public 	AudioClip[] 		collectSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		int cc = Random.Range (0, collectSound.Length);
		AudioSource.PlayClipAtPoint(collectSound[cc], transform.position);
	}

}
