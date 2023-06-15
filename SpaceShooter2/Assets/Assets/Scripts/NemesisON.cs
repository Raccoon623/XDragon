using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NemesisON : MonoBehaviour
{
    public string boolKey = "BoolValue";
    public bool boolValue = false;
    public Button falseButton;
    public Button trueButton;
    public GameObject objectToToggleOff;
    public GameObject objectToToggleOn;
    public TMP_Text textMesh; // Change the type to TMP_Text
    public Color onColor;
    public Color offColor;
    public GameObject colorChangeTarget; // Drag and drop the target object here

    private void Start()
    {
        falseButton.onClick.AddListener(SetFalse);
        trueButton.onClick.AddListener(SetTrue);

        LoadBoolValue();
        ToggleObjects();
        ChangeColor();
    }

    private void LoadBoolValue()
    {
        if (PlayerPrefs.HasKey(boolKey))
        {
            int savedValue = PlayerPrefs.GetInt(boolKey);
            boolValue = savedValue == 1;
        }
    }

    private void SaveBoolValue()
    {
        int valueToSave = boolValue ? 1 : 0;
        PlayerPrefs.SetInt(boolKey, valueToSave);
        PlayerPrefs.Save();
    }

    public void SetFalse()
    {
        boolValue = false;
        ToggleObjects();
        SaveBoolValue();
        ChangeColor();
    }

    public void SetTrue()
    {
        boolValue = true;
        ToggleObjects();
        SaveBoolValue();
        ChangeColor();
    }

    private void ToggleObjects()
    {
        if (objectToToggleOff != null)
            objectToToggleOff.SetActive(!boolValue);

        if (objectToToggleOn != null)
            objectToToggleOn.SetActive(boolValue);

        // Update the buttons' interactability based on the boolValue
        falseButton.interactable = boolValue;
        trueButton.interactable = !boolValue;
    }

    private void ChangeColor()
    {
        if (textMesh != null)
        {
            if (boolValue)
                textMesh.color = onColor;
            else
                textMesh.color = offColor;
        }

        if (colorChangeTarget != null)
        {
            Renderer renderer = colorChangeTarget.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (boolValue)
                    renderer.material.color = onColor;
                else
                    renderer.material.color = offColor;
            }
        }
    }
}