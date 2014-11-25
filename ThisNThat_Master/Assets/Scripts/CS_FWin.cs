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
		if (playanim == true && animprogress <= 3) 
		{
			animprogress = animprogress + 1;
			playanim = false;
		}

		else if (animprogress == 3)
		{
			animprogress = 3;
		}
	}
}
