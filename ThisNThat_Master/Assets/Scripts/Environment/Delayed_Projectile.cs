using UnityEngine;
using System.Collections;

public class Delayed_Projectile : MonoBehaviour 
{
	
	[HideInInspector]	public Vector3 ProjStartPos;
	
	public Vector3 MoveSpeed;

	public float waitTime;
	public float timer;

	public bool shouldMove;
	public GameObject warning;
	
	// Use this for initialization
	void Start () 
	{
		
		//ProjStartPos = gameObject.GetComponent<Transform>;
		ProjStartPos = gameObject.transform.position;
		warning.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer = timer - Time.deltaTime;

		if (timer <= 0)
			{
				MoveXYZ();
			}
		if (timer <= 2)
			{
				warning.SetActive (true);
			}
		if (timer >= 2.1f)
		{
			warning.SetActive (false);
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ground") 
		{
			gameObject.transform.position = ProjStartPos;
			timer = waitTime;
		}
	}
	
	void MoveXYZ()
	{
		this.transform.Translate (MoveSpeed.x * Time.deltaTime,MoveSpeed.y * Time.deltaTime, MoveSpeed.z * Time.deltaTime);
	}
}
