using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{

	private int _score = CrossSceneInfo.ScoreAchieved;
	private int _numberOfAssignmentsWrong = CrossSceneInfo.NumberOfAssignmentsWrong;
	private int _numberOfAssignmentsCorrect = CrossSceneInfo.NumberOfAssignmentsCorrect;
	
	[SerializeField] public TextMeshPro ScoreText;
	[SerializeField] public TextMeshPro NumbefOfCorrect;

	void Start ()
	{
		ScoreText.text = "You scored " + _score + "!";
		NumbefOfCorrect.text = "You played " + _numberOfAssignmentsCorrect + " out of " + 
		                       (_numberOfAssignmentsCorrect + _numberOfAssignmentsWrong) + " correct";
		
		CrossSceneInfo.Reset();
	}
	
}
