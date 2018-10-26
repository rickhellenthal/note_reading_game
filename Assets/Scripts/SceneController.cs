using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void LoadEndGame()
	{
		SceneManager.LoadScene("EndGame");
	}
}
