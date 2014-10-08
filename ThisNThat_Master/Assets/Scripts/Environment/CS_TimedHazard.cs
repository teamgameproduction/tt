using UnityEngine;
using System.Collections;

public class CS_TimedHazard : MonoBehaviour {

	public float StartAfterSec = 0.0f;
	public float WaitForSec = 3.0f;
	public float KillForSec = 2.0f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("StartAfterCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator StartAfterCoroutine(){
		yield return new WaitForSeconds(StartAfterSec);
		StartCoroutine ("KillCoroutine");
	}

	IEnumerator WaitCoroutine(){
		yield return new WaitForSeconds(WaitForSec);
		gameObject.renderer.enabled = true;
		StartCoroutine ("KillCoroutine");

	}

	IEnumerator KillCoroutine(){
		yield return new WaitForSeconds(KillForSec);
		gameObject.renderer.enabled = false;
		StartCoroutine ("WaitCoroutine");
	}

}
