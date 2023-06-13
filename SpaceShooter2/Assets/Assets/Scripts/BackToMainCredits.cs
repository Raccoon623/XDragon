using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainCredits : MonoBehaviour
{
    // Set this value in the inspector to control how long to wait before toggling the object on
    public float delay = 20f;
    public GameObject objectToToggleOn;

    void Start()
    {
        // Start the countdown timer
        StartCoroutine(ToggleObjectAfterDelay(delay));
    }

    IEnumerator ToggleObjectAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Toggle the specified object on
        if (objectToToggleOn != null)
        {
            objectToToggleOn.SetActive(true);
        }
    }
}