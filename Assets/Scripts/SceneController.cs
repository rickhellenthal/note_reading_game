using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

	[SerializeField] public Toggle IncludeSharpNotes;
	[SerializeField] public Toggle IncludeFlatNotes;

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
}
