using UnityEngine;
using System.Collections;

public class CS_SetActive : MonoBehaviour 
{
	public GameObject objectToSet;

	public GameObject winner;

	public GameObject part1;

	public CS_Generic_Pickup pickUp;

	// Use this for initialization
	void Start () 
	{
		objectToSet.SetActive (false);
	}

	void Awake ()
	{
		objectToSet = GameObject.Find ("PFB_WinVolume");
		pickUp = GameObject.Find("Winner").GetComponent <CS_Generic_Pickup> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (pickUp.pickedUp == true)
		{
			print ("dfdsfs");
			objectToSet.SetActive (true);
			part1.SetActive(true);
		}
	}
}
