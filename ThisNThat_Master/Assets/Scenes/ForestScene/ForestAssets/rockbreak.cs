using UnityEngine;
using System.Collections;

public class rockbreak : MonoBehaviour 
{
	public GameObject cage;
	public GameObject win;
	public GameObject win2;

	public GameObject part1;
	public GameObject part2;

	public bool isBroke = false;

	// Use this for initialization
	void Start () 
	{
		part1.SetActive (false);
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

			part1.SetActive (true);

			isBroke = true;
			gameObject.SetActive(false);
			cage.animation.Play("cagebreak");
			cage.SetActive (false);
			win2.SetActive (false);
		
		}
	}
}
