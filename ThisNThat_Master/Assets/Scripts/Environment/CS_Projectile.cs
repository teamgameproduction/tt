using UnityEngine;
using System.Collections;

public class CS_Projectile : MonoBehaviour {

	[HideInInspector]	public Vector3 ProjStartPos;

	public Vector3 MoveSpeed;

	// Use this for initialization
	void Start () {
	
		//ProjStartPos = gameObject.GetComponent<Transform>;
		ProjStartPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		MoveXYZ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground") 
		{
			gameObject.transform.position = ProjStartPos;

		}
	}

	void MoveXYZ(){
		this.transform.Translate (MoveSpeed.x * Time.deltaTime,MoveSpeed.y * Time.deltaTime, MoveSpeed.z * Time.deltaTime);
	}
}
