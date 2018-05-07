using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame ()
	{
		SceneManager.LoadScene ("Flashcard");
	}

	public void MemoryGame ()
	{
		SceneManager.LoadScene ("MemoryGame");
	}

	public void Draw ()
	{
		SceneManager.LoadScene ("Draw");
	}

	public void QuitGame ()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}
