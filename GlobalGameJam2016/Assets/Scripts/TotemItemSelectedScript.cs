using UnityEngine;
using System.Collections;

public class TotemItemSelectedScript : MonoBehaviour 
{
	//this script will run when a totem item is clicked, it will then push it into the first available totem slot.
	// Use this for initialization
	public TotemScript totemController;
	public string itemType = "itemtest";
	public Sprite mySprite;

	//we need a totem item - so that we can push to it
	//we need a type that is this item
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//if the item is clicked
	void OnMouseDown()
	{
		//the item has been clicked
		//now we put it into the first available slot in the totem

		totemController.setNextItem(itemType, mySprite);
	}
}
