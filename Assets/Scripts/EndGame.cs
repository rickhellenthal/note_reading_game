using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{

	private int _score = CrossSceneInfo.ScoreAchieved;
	private TextMeshPro _scoreText;

	void Start ()
	{
		_scoreText = GetComponent<TextMeshPro>();
		_scoreText.text = "You scored " + _score + "!";
		CrossSceneInfo.ScoreAchieved = 0;
	}
	
}
