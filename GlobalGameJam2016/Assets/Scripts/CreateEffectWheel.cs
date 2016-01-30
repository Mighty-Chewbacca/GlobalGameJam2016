using UnityEngine;
using System.Collections;

public class CreateEffectWheel : MonoBehaviour 
{

	public GameObject wheelPrefab;
	public GameObject wheelInstance;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
			{
			if (TotemItemSelectedScript.wheelActive == true)
				{
					//Debug.Log ("mouse button pressed");
					//Destroy (wheelInstance, 0.5f);
				}
			}
	}

	//if the item is clicked
	void OnMouseDown()
	{
		if (TotemItemSelectedScript.wheelActive == false) 
		{
			
			wheelInstance = Instantiate (wheelPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation) as GameObject;
			TotemItemSelectedScript.wheelActive = true;
		}
	}
}
