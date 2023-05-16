using UnityEngine;
using UnityEngine.SceneManagement;

public class afterdesctruction : MonoBehaviour
{
    // Build index of the scene to load after delay
    public int sceneIndex = 3;

    // Time delay in seconds before loading scene
    public float delay = 5.0f;

    private float timeElapsed = 0.0f;

    void Update()
    {
        // Increment time elapsed
        timeElapsed += Time.deltaTime;

        // Check if the time delay has elapsed
        if (timeElapsed >= delay)
        {
            // Load the new scene
            SceneManager.LoadScene(sceneIndex);
        }
    }
}