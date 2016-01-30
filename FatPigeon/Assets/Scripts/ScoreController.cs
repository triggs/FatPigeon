using UnityEngine;
using System.Collections;
using System;

public class ScoreController : MonoBehaviour {

    public GUIText scoreText;
    public GUIText endScoreText;
    public float totalScore;

    public ScoreController()
    {
        this.scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<GUIText>();
        this.endScoreText = GameObject.FindGameObjectWithTag("EndScoreText").GetComponent<GUIText>();
        totalScore = 0;
        this.scoreText.text = "Score: 0";
    }

    internal void ChangeScore(int changeByThisNumber)
    {
        totalScore += changeByThisNumber;
        scoreText.text = String.Format("Score: {0}", totalScore);
    }

    internal void ShowScore(bool show = true)
    {
        scoreText.enabled = show;
    }

    internal void ShowEndScore(bool show = false)
    {
        endScoreText.text = totalScore.ToString();
        endScoreText.enabled = show;
    }
}
