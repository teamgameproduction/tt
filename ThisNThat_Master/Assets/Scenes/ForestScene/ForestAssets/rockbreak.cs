using UnityEngine;
using System.Collections;

public class rockbreak : MonoBehaviour 
{
	public GameObject cage;
	public GameObject win;

	public bool isBroke = false;

	// Use this for initialization
	void Start () 
	{

	}
	
	void Awake ()
	{
		cage = GameObject.Find ("cage");
		win = GameObject.Find ("Winner");
		win.renderer.enabled = false;
		win.collider.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Rock")
		{
			win.renderer.enabled = true;
			win.collider.enabled = true;

			isBroke = true;
			gameObject.SetActive(false);
			cage.animation.Play("cagebreak");
			cage.SetActive (false);


		}
	}
}
