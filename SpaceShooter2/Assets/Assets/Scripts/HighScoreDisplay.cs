using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private string highScoreKey = "HighScore";

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void UpdateHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);

        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + score.ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt(highScoreKey, 0);
        PlayerPrefs.Save();
        highScoreText.text = "High Score: 0";
    }
}