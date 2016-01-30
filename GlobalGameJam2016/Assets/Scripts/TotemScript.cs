using UnityEngine;
using System.Collections;

public class TotemScript : MonoBehaviour 
{
	//this script will represent the totem pole
	//it will hold the items that have already been selected (5 items for now)

	public GameObject item1, item2, item3, item4, item5;
	public int currentItem = 1;
	public string item1type, item2type, item3type, item4type, item5type;
	public string[] correctList = new string[5];

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void setNextItem(string Itemtype, Sprite spriteIn)
	{
		if (currentItem < 6	)
		{
			if (currentItem == 1) 
			{
				item1.gameObject.GetComponent<SpriteRenderer>().sprite = spriteIn;
				item1type = Itemtype;
			}

			if (currentItem == 2) 
			{
				item2.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteIn;
				item2type = Itemtype;
			}

			if (currentItem == 3) 
			{
				item3.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteIn;
				item3type = Itemtype;
			}

			if (currentItem == 4) 
			{
				item4.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteIn;
				item4type = Itemtype;
			}

			if (currentItem == 5) 
			{
				item5.gameObject.GetComponent<SpriteRenderer> ().sprite = spriteIn;
				item5type = Itemtype;
			}

			currentItem++;
		}

	}

	public void CheckTotemPole()
	{
		int score = 0;
		string[] answerArray = new string[5];

		answerArray [0] = item1type;
		answerArray [1] = item2type;
		answerArray [2] = item3type;
		answerArray [3] = item4type;
		answerArray [4] = item5type;

		Debug.Log (answerArray[0]);
		Debug.Log (answerArray[1]);
		Debug.Log (answerArray[2]);
		Debug.Log (answerArray[3]);
		Debug.Log (answerArray[4]);

		Debug.Log (correctList[0]);
		Debug.Log (correctList[1]);
		Debug.Log (correctList[2]);
		Debug.Log (correctList[3]);
		Debug.Log (correctList[4]);

		for (int count = 0; count < answerArray.Length; count++) 
		{
			if (answerArray [count] == correctList [count]) 
			{
				score += 0;
			} 
			else 
			{
				//check if its in the list at all
				for (int i = 0; i < correctList.Length; i++)
				{
					if (answerArray [count] == correctList [i]) 
					{
						score += 1;
					} 
					else
					{
						if (i == 4)
						{
							score += 2;
						}
					}
				}
			}
		}

		Debug.Log ("score: " + score);
	}
}
