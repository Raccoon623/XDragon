using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private void Start()
    {
        // Call the LoadScene function after 3 seconds
        StartCoroutine(LoadSceneAfterDelay("Level1", 3f));
    }

    IEnumerator LoadSceneAfterDelay(string Level1, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the specified scene
        SceneManager.LoadScene(Level1);
    }
}