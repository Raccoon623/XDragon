using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int Score { get; private set; }
    public static int HighScore { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private string scoreKey = "Score";
    private string highScoreKey = "HighScore";

    private void Start()
    {
        Score = PlayerPrefs.GetInt(scoreKey, 0);
        HighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(highScoreKey, HighScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
        PlayerPrefs.SetInt(scoreKey, Score);
        PlayerPrefs.Save();
        UpdateScoreText();
    }

    public void ResetScore()
    {
        Score = 0;
        PlayerPrefs.SetInt(scoreKey, Score);
        PlayerPrefs.Save();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "HI Score: " + HighScore.ToString();
    }
}