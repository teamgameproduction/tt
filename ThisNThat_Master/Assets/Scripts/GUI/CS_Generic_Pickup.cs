using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_Generic_Pickup : MonoBehaviour 
{
	CS_HUD hud;

	//------Do Not Delete! For Win conditions in Forest! Thank You---- 
	public bool pickedUp = false;

	void Start () 
	{
		hud = GameObject.Find ("HUD Canvas").GetComponent<CS_HUD>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			IdentifyPickup();
	//------Do Not Delete! For Win conditions in Forest! Thank You---- 
			pickedUp = true;
			gameObject.SetActive (false);
		}
	}

	void IdentifyPickup()
	{
		if (gameObject.CompareTag("Small Coin"))		{	hud.SmallCoinCollected();	}
		else if (gameObject.CompareTag("Large Coin"))	{	hud.LargeCoinCollected();	}
		else if (gameObject.CompareTag("Critter"))		{	hud.CritterCollected();		}
	}

}
