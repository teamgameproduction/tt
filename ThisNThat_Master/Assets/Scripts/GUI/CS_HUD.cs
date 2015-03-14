using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CS_HUD : MonoBehaviour 
{
	public double currency = 0;
	public Text currencyText;

	private Animator collectAnimator;

	public Image collectableImg;
	public int collectableCount;
	public Sprite[] collectableSprites;

	void Awake()
	{
		collectAnimator = GetComponent<Animator>();
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
		collectAnimator.Play ("Anim_CollectableIn");
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
		yield return new WaitForSeconds(4.0f);
		collectAnimator.Play ("Anim_CollectableOut");
		yield return new WaitForSeconds(.5f);
		collectableImg.enabled = false;
	}

}
