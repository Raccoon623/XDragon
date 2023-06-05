using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static int Score { get; private set; }
    public static ScoreSystem Instance;

    public TextMeshProUGUI scoreText;
    private string scoreKey = "Score";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Score = PlayerPrefs.GetInt(scoreKey, 0);
        UpdateScoreText();
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        UpdateScoreText();
        PlayerPrefs.SetInt(scoreKey, Score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
}