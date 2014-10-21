using UnityEngine;
using System.Collections;

public class CS_FWin : MonoBehaviour 
{
	public int animprogress = 0;
	public bool playanim = false;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playanim == true) 
		{
			animprogress = animprogress + 1;
			playanim = false;
		}
	}
}
