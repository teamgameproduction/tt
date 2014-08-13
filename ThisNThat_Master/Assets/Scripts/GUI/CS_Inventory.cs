using UnityEngine;
using System.Collections;

public class CS_Inventory : MonoBehaviour 
{
	public static int pickupGauge = 0;
	
	
	// Use this for initialization
	void Start () 
	{
		pickupGauge = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void GenericPickup()
	{
		pickupGauge++;
	}
}
