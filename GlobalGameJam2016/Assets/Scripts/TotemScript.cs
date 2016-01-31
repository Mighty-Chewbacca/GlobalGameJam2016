using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotemScript : MonoBehaviour 
{
	//this script will represent the totem pole
	//it will hold the items that have already been selected (5 items for now)

	public GameObject effectItem, strengthItem, finalItem;
	public int currentItem = 1;
	public string itemEffect, itemStrength;
	public static string desiredEffect, desiredStrength;
	public string[] puzzleEffectSolutions = new string[5];
	public string[] puzzleStrengthSolutions = new string[5];
	public GameObject gameOverPanel;

	private AudioSource source;
	public AudioClip goodSound, badSound;

	public Sprite sun, heat, rain, food, breeze;

	public GameObject villageFace;
	public Sprite happy, meh, sad;

	public static int villageScore = 0;
	public int villageScoreTemp;

	public int currentPuzzle = 0;

	// Use this for initialization
	void Start () 
	{
		puzzleEffectSolutions [0] = "rain";
		puzzleEffectSolutions [1] = "sun";
		puzzleEffectSolutions [2] = "food";
		puzzleEffectSolutions [3] = "breeze";
		puzzleEffectSolutions [4] = "heat";

		puzzleStrengthSolutions [0] = "weak";
		puzzleStrengthSolutions [1] = "strong";
		puzzleStrengthSolutions [2] = "weak";
		puzzleStrengthSolutions [3] = "strong";
		puzzleStrengthSolutions [4] = "strong";

		source = GetComponent<AudioSource> ();
		gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		villageScoreTemp = TotemScript.villageScore;

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
			gameOverPanel.SetActive(true);
			gameOverPanel.gameObject.GetComponent<UnityEngine.UI.Text>().text = endGame();
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
		//draw the chosen rune in the slot
		if (itemEffect == "sun")
			finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = sun;

		if (itemEffect == "rain")
			finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = rain;

		if (itemEffect == "heat")
			finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = heat;

		if (itemEffect == "breeze")
			finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = breeze;

		if (itemEffect == "food")
			finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = food;

		//System.Threading.Thread.Sleep (2000);
		//StartCoroutine(waitPlease());

		print ("starting" + Time.time);
		StartCoroutine (waitPlease(2.0f));
		print("before wait and print finished");



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

	IEnumerator waitPlease(float waitTime)
	{
		yield return new WaitForSeconds (waitTime);
		print ("wait and print" + Time.time);
		finalItem.gameObject.GetComponent<SpriteRenderer>().sprite = null;
	}

	public string endGame()
	{
		if (villageScore > 2) 
		{
			return "Boo! you ruined the village.";
		} 
		else if (villageScore < -2)
		{
			return "Well done, the village is pleased!";
		}
		else
		{
			return "You left the village as you arrived - no difference.";
		}
	}
}
