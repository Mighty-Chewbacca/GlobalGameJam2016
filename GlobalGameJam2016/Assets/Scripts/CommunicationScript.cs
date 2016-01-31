using UnityEngine;
using System.Collections;

public class CommunicationScript : MonoBehaviour 
{

	public bool messageShowing = false;
	public Vector2 objectPos;
	public GUISkin mySkin;
	public bool alignLeft;
	public Texture villagetex, strengthtex, effecttex, heattex, raintex, suntex, foodtex, breezetex, strongtex, weaktex;
	public Texture breeze, food, heat, rain, sun;
	public bool forceShow;
	public bool isTaskGiver;


	private AudioSource source;
	public AudioClip soundclip;

	// Use this for initialization
	void Start () 
	{
		objectPos = Camera.main.WorldToScreenPoint (this.gameObject.transform.position);
		if (forceShow)
			messageShowing = true;

		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isTaskGiver) 
		{
			if (TotemScript.desiredEffect == "food") 
			{
				effecttex = foodtex;
				villagetex = food;
			}
			if (TotemScript.desiredEffect == "breeze") 
			{
				effecttex = breezetex;
				villagetex = breeze;
			}
			if (TotemScript.desiredEffect == "heat") 
			{
				effecttex = heattex;
				villagetex = heat;
			}
			if (TotemScript.desiredEffect == "sun") 
			{
				effecttex = suntex;
				villagetex = sun;
			}
			if (TotemScript.desiredEffect == "rain") 
			{
				effecttex = raintex;
				villagetex = rain;
			}

			if (TotemScript.desiredStrength == "strong") 
			{
				strengthtex = strongtex;
			}
			if (TotemScript.desiredStrength == "weak") 
			{
				strengthtex = weaktex;
			}
		}
	}

	void OnMouseEnter()
	{
		source.PlayOneShot (soundclip);
	}

	void OnMouseOver()
	{
		//mouse hovering, display message
		messageShowing = true;
	}

	void OnMouseExit()
	{
		//mouse left, dinnae show message anymore#
		if (!forceShow)
		messageShowing = false;
	}

	void OnGUI()
	{
		GUI.skin = mySkin;
		if (messageShowing) 
		{

			if (alignLeft)
			{
				GUI.Box (new Rect (objectPos.x - 75, (Screen.height - objectPos.y - 175), 250, 100), "");
				GUI.DrawTexture (new Rect(objectPos.x - 50, (Screen.height - objectPos.y - 155), 50, 50), villagetex);
				GUI.DrawTexture (new Rect(objectPos.x + 10, (Screen.height - objectPos.y - 155), 50, 50), effecttex);
				GUI.DrawTexture (new Rect(objectPos.x + 70, (Screen.height - objectPos.y - 155), 50, 50), strengthtex);
			} 
			else
			{
				GUI.Box (new Rect (objectPos.x - 175, (Screen.height - objectPos.y - 175), 250, 100), "");
				GUI.DrawTexture (new Rect(objectPos.x - 155, (Screen.height - objectPos.y - 155), 50, 50), villagetex);
				GUI.DrawTexture (new Rect(objectPos.x - 95, (Screen.height - objectPos.y - 155), 50, 50), effecttex);
				GUI.DrawTexture (new Rect(objectPos.x - 35, (Screen.height - objectPos.y - 155), 50, 50), strengthtex);
			}
		}
	}
}
