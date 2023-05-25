using UnityEngine;

public class ObjectStateController : MonoBehaviour
{
    public static bool isObjectOn = false;
    public GameObject objectToCheck;

    private void Update()
    {
        if (objectToCheck != null)
        {
            isObjectOn = objectToCheck.activeSelf;
        }
    }
}