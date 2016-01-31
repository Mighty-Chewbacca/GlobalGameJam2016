using UnityEngine;
using System.Collections;

public class playSoundIfClicked : MonoBehaviour 
{

	private AudioSource source;
	public AudioClip soundclip;

	// Use this for initialization
	void Start () 
	{
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		source.PlayOneShot (soundclip);
	}
}
