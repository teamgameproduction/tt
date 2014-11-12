using UnityEngine;
using System.Collections;

public class CS_EnviroRespawn : MonoBehaviour {

	[HideInInspector]	public Vector3 StartPos;
	public float RespawnTime;


	// Use this for initialization
	void Start () {
	
		StartPos = gameObject.transform.position;
		StartCoroutine ("RespawnTimer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RespawnTimer(){

		yield return new WaitForSeconds (RespawnTime);
		gameObject.transform.position = StartPos;
		StartCoroutine ("RespawnTimer");
	}

}
