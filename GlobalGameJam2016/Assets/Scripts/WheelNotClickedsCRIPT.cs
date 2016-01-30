using UnityEngine;
using System.Collections;

public class WheelNotClickedsCRIPT : MonoBehaviour 
{
	public bool mouseOver = true;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (1)) 
		{
			Debug.Log ("destroy wheel");
			Destroy (this.gameObject, 0.0f);
			TotemItemSelectedScript.wheelActive = false;
		}
	}
}
