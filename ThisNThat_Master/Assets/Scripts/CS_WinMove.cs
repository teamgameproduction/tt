using UnityEngine;
using System.Collections;

public class CS_WinMove : MonoBehaviour 
{
	public GameObject Winner;
	public rockbreak rock;
	[HideInInspector]	public GameObject 	gmcharacterBlue;
	[HideInInspector]	public GameObject 	gmcharacterRed;

	public GameObject cbox1;
	public GameObject cbox2;
	



	public bool isTouch = false;
	public bool isRedTouching;
	public bool isBlueTouching;

	
	public CS_FWin fWin;

	void Start ()
	{
		Winner = GameObject.Find ("Winner");
		fWin = GameObject.Find ("Winner").GetComponent <CS_FWin> ();
		rock = GameObject.Find("RockRoot").GetComponent <rockbreak> ();
		gmcharacterBlue = GameObject.Find ("characterBlue");
		gmcharacterRed = GameObject.Find ("characterRed");
		cbox1 = GameObject.Find ("WinAnimation05");
		cbox2 = GameObject.Find ("WinAnimation06");
	}
	
	void Awake () 
	{
		//Winner = GameObject.Find ("Winner");
		//fWin = GameObject.Find ("Winner").GetComponent <CS_FWin> ();
	}
	void Update () 
	{

	}

	void OnTriggerEnter (Collider other)
	{

		{
			if (other.gameObject.name == "characterRed") 
			{
				//Debug.Log ("I dig that");
				isRedTouching = true;
			}
		}
		{
			if (other.gameObject.name == "characterBlue") 
			{
				//Debug.Log ("I dig that");
				isBlueTouching = true;
			}
		}

		if (rock.isBroke == true)
		{
			if (other.gameObject.tag == "Player")
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
					gameObject.collider.enabled = false;
				}
				if (fWin.animprogress == 4 && isRedTouching == true && isBlueTouching == true) 
				{
					isTouch = true;
					Winner.collider.enabled = true;
				}

				else if (fWin.animprogress == 4 && isRedTouching == true && isBlueTouching == false) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim05");
					fWin.playanim = true;
					fWin.animprogress = 5;
					cbox1.SetActive(true);
					cbox2.SetActive(false);
				}

				else if (fWin.animprogress == 4 && isRedTouching == false && isBlueTouching == true) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim05");
					fWin.playanim = true;
					fWin.animprogress = 5;
					cbox1.SetActive(false);
					cbox2.SetActive(true);
				}

				else if (fWin.animprogress == 5 && isRedTouching == false && isBlueTouching == true) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim06");
					fWin.playanim = true;
					fWin.animprogress = 4;
					cbox1.SetActive(true);
					cbox2.SetActive(false);
				}

				else if (fWin.animprogress == 5 && isRedTouching == true && isBlueTouching == false) 
				{
					isTouch = true;
					Winner.animation.Play("winAnim06");
					fWin.playanim = true;
					fWin.animprogress = 4;
					cbox1.SetActive(false);
					cbox2.SetActive(true);
				}
				if (fWin.animprogress == 5 && isRedTouching == true && isBlueTouching == true) 
				{
					isTouch = true;
					Winner.collider.enabled = true;
				}
			}
		}
			

	}

	void OnTriggerExit(Collider other)
	{
		{
			if (other.gameObject.name == "characterRed") 
			{
				//Debug.Log ("I dig that");
				isRedTouching = false;
			}
		}
		{
			if (other.gameObject.name == "characterBlue") 
			{
				//Debug.Log ("I dig that");
				isBlueTouching = false;
			}
		}
	}
}
