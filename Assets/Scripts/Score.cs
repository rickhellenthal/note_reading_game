using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

	private int _score;
	private float _timeItTook;
	private TextMeshPro _scoreboardText;

	void Start()
	{
		_score = 0;
		_scoreboardText = GetComponent<TextMeshPro>();
	}

	void Update()
	{
		_timeItTook += Time.deltaTime;
	}


	public void UpdateScore(bool noteHasBeenPlayedWrong)
	{
		if (!noteHasBeenPlayedWrong)
		{
			int scoreToAdd = 100 - (10 * (int) Math.Round(_timeItTook));
			if (scoreToAdd < 0) 
			{
				scoreToAdd = 0;
			}

			_score += scoreToAdd;
			_scoreboardText.text = "Score: " + _score;

		}
		_timeItTook = 0.0f;
	}

	public int GetScore()
	{
		return _score;
	}

}
