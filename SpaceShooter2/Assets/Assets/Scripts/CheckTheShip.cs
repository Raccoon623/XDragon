using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject objectA;
    public GameObject objectB;
    private bool hasRun = false;

    private void Start()
    {
        // Make sure the required game objects are assigned
        if (objectA == null || objectB == null)
        {
            Debug.LogError("One or both game objects are not assigned in ToggleObjects.");
            return;
        }

        // Toggle the game objects based on the initial state of isObjectOn
        if (!hasRun)
        {
            ToggleGameObjects();
            hasRun = true;
        }
    }

    private void ToggleGameObjects()
    {
        if (ObjectStateController.isObjectOn)
        {
            objectA.SetActive(true);
            objectB.SetActive(false);
        }
        else
        {
            objectA.SetActive(false);
            objectB.SetActive(true);
        }
    }
}