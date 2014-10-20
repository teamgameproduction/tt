using UnityEngine;
using System.Collections;

public class CS_winMove : MonoBehaviour 
{
	public GameObject Winner;
	public bool win01IsTouch = false;
	public bool win02IsTouch = false;
	public bool win03IsTouch = false;
	public bool win04IsTouch = false;
	public GameObject winA01;
	public GameObject winA02;
	public GameObject winA03;
	public GameObject winA04;


	// Use this for initialization
	void Start () 
	{
		Winner = GameObject.Find ("Winner");
		winA01 = GameObject.Find ("WinAnimation01");
		winA02 = GameObject.Find ("WinAnimation02");
		winA03 = GameObject.Find ("WinAnimation03");
		winA04 = GameObject.Find ("WinAnimation04");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player" && (win01IsTouch = true)) 
			{
				Winner.animation.Play("winAnim01");
			}
		if (other.gameObject.tag == "Player" && (win02IsTouch = true)) 
			{
				Winner.animation.Play("winAnim02");
			}
		if (other.gameObject.tag == "Player" && (win03IsTouch = true)) 
			{
				Winner.animation.Play("winAnim03");
			}
		if (other.gameObject.tag == "Player" && (win04IsTouch = true)) 
			{
				Winner.animation.Play("winAnim04");
			}


	}
}
