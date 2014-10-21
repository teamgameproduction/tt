using UnityEngine;
using System.Collections;

public class CS_winMove : MonoBehaviour 
{
	public GameObject Winner;

	public bool isTouch = false;
	
	public CS_FWin fWin;
	
	void Start () 
	{
		Winner = GameObject.Find ("Winner");
		fWin = GameObject.Find ("Winner").GetComponent <CS_FWin> ();
		
	}
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && fWin.animprogress == 0) 
			{
				isTouch = true;
				Winner.animation.Play("winAnim01");
				gameObject.collider.enabled = false;
				fWin.playanim = true;
			}

		else if (other.gameObject.tag == "Player" && fWin.animprogress == 1) 
		{
			isTouch = true;
			Winner.animation.Play("winAnim02");
			gameObject.collider.enabled = false;
			fWin.playanim = true;
		}
	}
}
