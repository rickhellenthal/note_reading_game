using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

	private int _score;
	private float _timeItTook;
	[SerializeField] public TextMeshPro ScoreboardText;

	void Start()
	{
		_score = 0;
	}

	/*
     * This counts the amount of time it took the player to play the correct note.
     */
	void Update()
	{
		_timeItTook += Time.deltaTime;
	}


	/*
	 * This give the player points based on the time it took to play the correct note.
	 * If the assignment has failed before (the player played the wrong note first), no points are awarded.
	 * Resets the timer _timeItTook.
     */
	public void UpdateScore(bool noteHasBeenPlayedWrong)
	{
		if (!noteHasBeenPlayedWrong)
		{
			int scoreToAdd = 100 - (5 * (int) Math.Round(_timeItTook));
			if (scoreToAdd < 0) 
			{
				scoreToAdd = 0;
			}

			_score += scoreToAdd;
			ScoreboardText.text = "Score: " + _score;

		}
		_timeItTook = 0.0f;
	}

	public int GetScore()
	{
		return _score;
	}

}
