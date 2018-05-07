using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour {
	public cards againGO;
	public void MainMenu ()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void PlayAgain ()
	{
		SceneManager.LoadScene ("MemoryGame");
	}

}
