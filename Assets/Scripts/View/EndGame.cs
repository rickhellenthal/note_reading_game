using Model;
using TMPro;
using UnityEngine;

namespace View
{
	public class EndGame : MonoBehaviour
	{
		private readonly int _score = CrossSceneInfo.ScoreAchieved;
		private readonly int _numberOfAssignmentsWrong = CrossSceneInfo.NumberOfAssignmentsWrong;
		private readonly int _numberOfAssignmentsCorrect = CrossSceneInfo.NumberOfAssignmentsCorrect;
	
		[SerializeField] public TextMeshPro ScoreText;
		[SerializeField] public TextMeshPro NumberOfCorrect;

		void Start ()
		{
			SetTextValues();
			CrossSceneInfo.Reset();
		}

		/*
	 * This sets the text values in the EndGame scene to the values that were retrieved from CrossSceneInfo.
	 */
		void SetTextValues()
		{
			ScoreText.text = "You scored " + _score + "!";
			NumberOfCorrect.text = "You played " + _numberOfAssignmentsCorrect + " out of " + 
			                       (_numberOfAssignmentsCorrect + _numberOfAssignmentsWrong) + " correct";
		}
	
	}
}
