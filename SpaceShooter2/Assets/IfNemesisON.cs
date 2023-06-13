using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNemesisON : MonoBehaviour
{
    public string boolValueKey = "NemesisBoolValue";
    public bool defaultValue = true;
    public GameObject objectToToggleOn;
    public GameObject objectToToggleOff;

    private void Start()
    {
        bool boolValue = PlayerPrefs.GetInt(boolValueKey, defaultValue ? 1 : 0) != 0;

        if (boolValue)
        {
            ToggleObjects();
        }
    }

    private void ToggleObjects()
    {
        if (objectToToggleOn != null)
        {
            objectToToggleOn.SetActive(true);
        }

        if (objectToToggleOff != null)
        {
            objectToToggleOff.SetActive(false);
        }
    }
}
