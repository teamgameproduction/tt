using UnityEngine;
using System.Collections;

public class CS_BreakablePlatform : MonoBehaviour 
{
	private CS_GenericTrigger CollisionBool;
	public GameObject TriggerVolume;
	public float destroyTimer;
	
	void Start () 
	{
		CollisionBool = TriggerVolume.GetComponent<CS_GenericTrigger>();
	}

	void Update () 
	{
		if (destroyTimer == 0f)
		{}
		else if (CollisionBool.collision && destroyTimer > 0f)
		{
			destroyTimer -= Time.deltaTime;
		}
		else if (CollisionBool.collision && destroyTimer <= 0f)
		{
			DestroyObject(this.gameObject);
		}
	}
}
