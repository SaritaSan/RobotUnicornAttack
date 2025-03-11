using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoresGameOver : MonoBehaviour
{
    [SerializeField]
    private List<Text> scoresTexts;
    [SerializeField]
    private Text finalScoreText;
    private int scoreIndex = 0;

    public void SetScore(int score)
    {
        scoresTexts[scoreIndex].text = score.ToString();
        scoreIndex++;
    }

    public void SetFinalScore(int score)
    {
        finalScoreText.text = score.ToString();
    }

    public void Reset()
    {
        scoreIndex = 0;
        finalScoreText.text = "0";
        foreach (Text scoreText in scoresTexts)
        {
            scoreText.text = "0";
        }

    }
}
