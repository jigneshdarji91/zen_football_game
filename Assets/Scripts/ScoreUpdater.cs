using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreUpdater : MonoBehaviour {

	static float score;
	static bool countScore;
	static int highscore;

	// Use this for initialization
	void Start () {

		highscore = PlayerPrefs.GetInt ("Highscore");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (countScore) 
		{
			score += Time.deltaTime;
		}
		DisplayScore ();
	}

	void DisplayScore()
	{
		guiText.text = "Score\n" + (int)score + "\nHighscore:\n" + (int) highscore;
	}

	public static void ResetScore() 
	{
		if ((int)score > highscore)
			PlayerPrefs.SetInt ("Highscore", (int)score);
		PlayerPrefs.SetInt ("PreviousScore", (int)score);
		score = 0;
		highscore = PlayerPrefs.GetInt ("Highscore");
		StopCounting ();
	}

	public static void StartCounting()
	{
		countScore = true;
	}

	public static void StopCounting()
	{
		countScore = false;
	}
}
