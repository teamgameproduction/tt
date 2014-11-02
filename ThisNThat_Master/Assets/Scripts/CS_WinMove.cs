using UnityEngine;
using System.Collections;

public class CS_WinMove : MonoBehaviour 
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
		if (other.tag == "Player")
			{
				if (fWin.animprogress == 0) 
					{
						isTouch = true;
						Winner.animation.Play("winAnim01");
						gameObject.collider.enabled = false;
						fWin.playanim = true;
					}

				else if (fWin.animprogress == 1) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim02");
					gameObject.collider.enabled = false;
					fWin.playanim = true;
				}

				else if (fWin.animprogress == 2) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim03");
					fWin.playanim = true;
					gameObject.collider.enabled = false;
				}

				else if (fWin.animprogress == 3) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim04");
					fWin.playanim = true;
				}
				
				else if (fWin.animprogress == 4) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim05");
					fWin.playanim = true;
				}

				else if (fWin.animprogress == 5) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim04");
					fWin.playanim = true;
				}

				else if (fWin.animprogress == 6) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim05");
					fWin.playanim = true;
				}
			}

	}
}
