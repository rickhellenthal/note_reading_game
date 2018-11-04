using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

	[SerializeField] public Toggle IncludeSharpNotes;

	public void LoadGame()
	{
		CrossSceneInfo.IncludeSharpNotes = IncludeSharpNotes.isOn;
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
