using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool hasResetScore = false;

    private void Start()
    {
        // Find the ScoreManager component in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null && !hasResetScore)
        {
            scoreManager.ResetScore();
            hasResetScore = true;
        }
    }
}