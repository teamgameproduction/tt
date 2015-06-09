using UnityEngine;
using System.Collections;

public class CS_collect_Audio : MonoBehaviour {
	public 	AudioClip[] 		collectSound;
	public bool hasPlayed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		if (hasPlayed == false) {
						int cc = Random.Range (0, collectSound.Length);
						AudioSource.PlayClipAtPoint (collectSound [cc], transform.position);
			            hasPlayed = true;
				} else {
				}
	}

}
