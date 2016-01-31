using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
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

	public void PlayGame()
	{
		source.PlayOneShot (soundclip);
		SceneManager.LoadScene (1);
	}

	public void QuitGame()
	{
		source.PlayOneShot (soundclip);
		Application.Quit ();
	}
}
