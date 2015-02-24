using UnityEngine;
using System.Collections;

public class CS_destructSound : MonoBehaviour {
	public 	AudioClip[] 		crushSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		int c = Random.Range (0, crushSound.Length);
		AudioSource.PlayClipAtPoint(crushSound[c], transform.position);	
	}


}
