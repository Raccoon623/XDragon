using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainCredits : MonoBehaviour
{
    // Set this value in the inspector to control how long to wait before changing scenes
    public float delay = 20f;

    void Start()
    {
        // Start the countdown timer
        StartCoroutine(ChangeSceneAfterDelay(delay));
    }

    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Load the scene with build index 0
        SceneManager.LoadScene(0);
    }
}