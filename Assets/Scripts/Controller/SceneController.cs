using System;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controller
{
	public class SceneController : MonoBehaviour
	{

		[SerializeField] public Toggle IncludeSharpNotes;
		[SerializeField] public Toggle IncludeFlatNotes;

		public void StartRight()
		{
			CrossSceneInfo.ClefSetting = 0;
			LoadGame(false);
		}

		public void StartLeft()
		{
			CrossSceneInfo.ClefSetting = 1;
			LoadGame(false);
		}

		public void StartBoth()
		{
			CrossSceneInfo.ClefSetting = 2;
			LoadGame(false);
		}
		
		public void LoadGame(bool playAgain)
		{
			if (!playAgain)
			{
				CrossSceneInfo.IncludeSharpNotes = IncludeSharpNotes.isOn;
				CrossSceneInfo.IncludeFlatNotes = IncludeFlatNotes.isOn;
			}
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

		public void LoadHowToPlay()
		{
			SceneManager.LoadScene("HowToPlay");
		}
	}
}
