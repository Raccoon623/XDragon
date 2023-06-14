using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreReset : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool hasResetScore = false;

    private void Start()
    {
        // Check if the current scene is Level1
        if (SceneManager.GetActiveScene().buildIndex == 2)
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
}