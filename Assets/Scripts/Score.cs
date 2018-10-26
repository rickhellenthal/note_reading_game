using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

	private int _score;
	private float _timeItTook = 0.0f;
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
			_score += 100 - (10 * (int) Math.Round(_timeItTook));
			_scoreboardText.text = "Score: " + _score.ToString();

		}
		_timeItTook = 0.0f;
	}

}
