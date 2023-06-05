using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "High Score: " + score.ToString();
    }
}