using UnityEngine;
using TMPro;

public class NoScore : MonoBehaviour
{
    private HighScoreDisplay highScoreDisplay;

    private void Start()
    {
        highScoreDisplay = FindObjectOfType<HighScoreDisplay>();
    }

    public void ResetTopScore()
    {
        highScoreDisplay.ResetHighScore();
    }
}