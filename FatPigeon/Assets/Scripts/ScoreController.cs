using UnityEngine;
using System.Collections;
using System;

public class ScoreController : MonoBehaviour {

    public GUIText scoreText;
    public GUIText endScoreText;
    public GUIText gameOverText;
    public float totalScore;

    public ScoreController()
    {
        this.scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<GUIText>();
        this.endScoreText = GameObject.FindGameObjectWithTag("EndScoreText").GetComponent<GUIText>();
        this.gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<GUIText>();
        totalScore = 0;
        this.scoreText.text = "Score: 0";
    }

    internal void ChangeScore(int changeByThisNumber)
    {
        totalScore = Math.Max(totalScore + changeByThisNumber, 0);
        scoreText.text = String.Format("Score: {0}", totalScore);
    }

    internal void ResetScore()
    {
        totalScore = 0;
        scoreText.text = String.Format("Score: {0}", totalScore);
    }

    internal void ShowScore(bool show = true)
    {
        scoreText.enabled = show;
    }

    internal void ShowEndScore(bool show = false)
    {
        gameOverText.text = "Game Over.";
        gameOverText.enabled= show;
        endScoreText.text = String.Format("You Scored: {0}",totalScore.ToString());
        endScoreText.enabled = show;
    }
}
