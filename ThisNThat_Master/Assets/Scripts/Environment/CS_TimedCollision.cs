using UnityEngine;
using System.Collections;

public class CS_TimedCollision : MonoBehaviour {

	public float StartAfterSec = 0.0f;
	public float WaitForSec = 3.0f;
	public float CollideForSec = 2.0f;
	
	// Use this for initialization
	void Start () {

		StartCoroutine ("StartAfterCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator StartAfterCoroutine(){
		yield return new WaitForSeconds(StartAfterSec);
		StartCoroutine ("CollideCoroutine");
	}
	
	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds(WaitForSec);
		gameObject.collider.enabled = true;
		StartCoroutine ("CollideCoroutine");
		
	}
	
	IEnumerator CollideCoroutine(){
		yield return new WaitForSeconds(CollideForSec);
		gameObject.collider.enabled = false;
		StartCoroutine ("WaitCoroutine");
	}
	
}
