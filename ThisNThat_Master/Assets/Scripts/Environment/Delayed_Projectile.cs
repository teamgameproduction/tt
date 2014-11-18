using UnityEngine;
using System.Collections;

public class Delayed_Projectile : MonoBehaviour 
{
	
	[HideInInspector]	public Vector3 ProjStartPos;
	
	public Vector3 MoveSpeed;
	public float waitTime;

	public bool shouldMove;
	
	// Use this for initialization
	void Start () 
	{
		
		//ProjStartPos = gameObject.GetComponent<Transform>;
		ProjStartPos = gameObject.transform.position;
		StartCoroutine("MoveTime");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (shouldMove == true)
		    {
				MoveXYZ();
			}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground") 
		{
			gameObject.transform.position = ProjStartPos;
			shouldMove = false;
		}
	}
	
	void MoveXYZ()
	{
		this.transform.Translate (MoveSpeed.x * Time.deltaTime,MoveSpeed.y * Time.deltaTime, MoveSpeed.z * Time.deltaTime);
	}

	IEnumerator MoveTime()
	{
		yield return new WaitForSeconds (waitTime);
		shouldMove = true;
		StopCoroutine("MoveTime");
		StartCoroutine("MoveTime");
	}
}
