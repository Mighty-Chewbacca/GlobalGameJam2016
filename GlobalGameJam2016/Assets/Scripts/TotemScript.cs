using UnityEngine;
using System.Collections;

public class TotemScript : MonoBehaviour 
{
	//this script will represent the totem pole
	//it will hold the items that have already been selected (5 items for now)

	public GameObject effectItem, strengthItem;
	public int currentItem = 1;
	public string itemEffect, itemStrength;
	public static string desiredEffect, desiredStrength;
	public string[] puzzleEffectSolutions = new string[5];
	public string[] puzzleStrengthSolutions = new string[5];

	private AudioSource source;
	public AudioClip goodSound, badSound;

	public GameObject villageFace;
	public Sprite happy, meh, sad;

	public static int villageScore = 0;

	public int currentPuzzle = 0;

	// Use this for initialization
	void Start () 
	{
		puzzleEffectSolutions [0] = "rock";
		puzzleEffectSolutions [1] = "skull";
		puzzleEffectSolutions [2] = "skull";
		puzzleEffectSolutions [3] = "owl";
		puzzleEffectSolutions [4] = "rock";

		puzzleStrengthSolutions [0] = "rock";
		puzzleStrengthSolutions [1] = "rock";
		puzzleStrengthSolutions [2] = "shoe";
		puzzleStrengthSolutions [3] = "log";
		puzzleStrengthSolutions [4] = "shoe";

		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentPuzzle == 0) 
		{
			TotemScript.desiredEffect = puzzleEffectSolutions [0];
			TotemScript.desiredStrength = puzzleStrengthSolutions [0];
		}
		if (currentPuzzle == 1) 
		{
			TotemScript.desiredEffect = puzzleEffectSolutions [1];
			TotemScript.desiredStrength = puzzleStrengthSolutions [1];
		}
		if (currentPuzzle == 2) 
		{
			TotemScript.desiredEffect = puzzleEffectSolutions [2];
			TotemScript.desiredStrength = puzzleStrengthSolutions [2];
		}
		if (currentPuzzle == 3) 
		{
			TotemScript.desiredEffect = puzzleEffectSolutions [3];
			TotemScript.desiredStrength = puzzleStrengthSolutions [3];
		}
		if (currentPuzzle == 4) 
		{
			TotemScript.desiredEffect = puzzleEffectSolutions [4];
			TotemScript.desiredStrength = puzzleStrengthSolutions [4];
		}

		//change the smiley face
		if (villageScore > 2) 
		{
			villageFace.gameObject.GetComponent<SpriteRenderer>().sprite = sad;
		}
		else if (villageScore < -2) 
		{
			villageFace.gameObject.GetComponent<SpriteRenderer>().sprite = happy;
		}
		else  
		{
			villageFace.gameObject.GetComponent<SpriteRenderer>().sprite = meh;
		}


		if (currentPuzzle > 4) 
		{
			//win message
		}
	}

	public void setEffect(string itemeffect, Sprite spriteIn)
	{
		itemEffect = itemeffect;
		effectItem.gameObject.GetComponent<SpriteRenderer>().sprite = spriteIn;
		effectItem.gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		Destroy (effectItem.gameObject.GetComponent<BoxCollider2D> ());
		effectItem.AddComponent<BoxCollider2D> ();
	}

	public void setStrength(string itemstrength, Sprite spriteIn)
	{
		itemStrength = itemstrength;
		strengthItem.gameObject.GetComponent<SpriteRenderer>().sprite = spriteIn;
		strengthItem.gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		Destroy (strengthItem.gameObject.GetComponent<BoxCollider2D> ());
		strengthItem.AddComponent<BoxCollider2D> ();

	}

	public void CheckTotemPole()
	{
		if (itemEffect == TotemScript.desiredEffect && itemStrength == TotemScript.desiredStrength) 
		{
			//got the correct combination
			Debug.Log("correct combination");
			TotemScript.villageScore -= 2;
			source.PlayOneShot (goodSound);
			currentPuzzle++;
		} 
		else
		{
			//got the wrong combo
			Debug.Log("incorrect combination");
			TotemScript.villageScore += 3;
			source.PlayOneShot (badSound);
			currentPuzzle++;
		}
	}
}
