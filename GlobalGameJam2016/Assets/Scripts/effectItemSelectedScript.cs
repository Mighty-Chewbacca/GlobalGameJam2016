using UnityEngine;
using System.Collections;

public class effectItemSelectedScript : MonoBehaviour 
{
	public GameObject totemObject;
	public TotemScript totemController;
	public string itemType = "itemtest";
	public Sprite mySprite;
	public string itemEffect;


	// Use this for initialization
	void Start () 
	{
		totemObject = GameObject.Find ("totemcontroller");
		totemController = totemObject.GetComponent<TotemScript> ();
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

		totemController.setEffect (itemEffect, mySprite);
		Destroy (this.gameObject.transform.parent.gameObject);
		TotemItemSelectedScript.wheelActive = false;
	}
}
