using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{

	private int _score = CrossSceneInfo.ScoreAchieved;
	[SerializeField] public TextMeshPro ScoreText;

	void Start ()
	{
		ScoreText.text = "You scored " + _score + "!";
		CrossSceneInfo.ScoreAchieved = 0;
	}
	
}
