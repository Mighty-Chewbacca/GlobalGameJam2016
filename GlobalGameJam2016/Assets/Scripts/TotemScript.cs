using UnityEngine;
using System.Collections;

public class TotemScript : MonoBehaviour 
{
	//this script will represent the totem pole
	//it will hold the items that have already been selected (5 items for now)

	public GameObject effectItem, strengthItem;
	public int currentItem = 1;
	public string itemEffect, itemStrength;
	public string desiredEffect, desiredStrength;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void setEffect(string itemeffect, Sprite spriteIn)
	{
		itemEffect = itemeffect;
		effectItem.gameObject.GetComponent<SpriteRenderer>().sprite = spriteIn;
	}

	public void setStrength(string itemstrength, Sprite spriteIn)
	{
		itemStrength = itemstrength;
		strengthItem.gameObject.GetComponent<SpriteRenderer>().sprite = spriteIn;
	}

	public void CheckTotemPole()
	{
		if (itemEffect == desiredEffect && itemStrength == desiredStrength) 
		{
			//got the correct combination
			Debug.Log("correct combination");
		} 
		else
		{
			//got the wrong combo
			Debug.Log("incorrect combination");
		}


		//series of if statements which now enact the choice that the player made - wether right or wrong.

		//if rain and strong

		//if rain and medium

		//if rain and weak

		//if heat and strong

		//if heat and medium

		//if heat and weak

		//etc etc
	}
}
