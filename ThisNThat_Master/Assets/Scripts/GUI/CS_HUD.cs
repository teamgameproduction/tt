using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_HUD : MonoBehaviour 
{
	public double currency = 0;
	public Text currencyText;

	public Image collectableImg;
	public int collectableCount;
	public Sprite[] collectableSprites;

	void Awake()
	{
		currencyText = GameObject.Find ("Currency").GetComponent<Text>();
		collectableImg = GameObject.Find ("CollectableImage").GetComponent<Image>();
		collectableImg.enabled = false;
	}

	void Start () 
	{
		currencyText.text = "" + currency;
	}

	public void CritterCollected()
	{
		currency += 100;
		currencyText.text = "" + currency;

		collectableImg.enabled = true;
		collectableCount ++;
		collectableImg.sprite = collectableSprites[collectableCount];
		StartCoroutine(CollectablesVisible());
	}

	public void SmallCoinCollected()
	{
		currency += 10;
		currencyText.text = "" + currency;
	}

	public void LargeCoinCollected()
	{
		currency += 50;
		currencyText.text = "" + currency;
	}
	
	public IEnumerator CollectablesVisible()
	{
		Debug.Log("Counting Down");
		yield return new WaitForSeconds(3.0f);
		Debug.Log("Counting Done");
		collectableImg.enabled = false;
	}

}
