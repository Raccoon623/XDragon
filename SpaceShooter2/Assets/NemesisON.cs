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
    public TextMeshProUGUI textMesh;
    public Color onColor;
    public Color offColor;

    private void Start()
    {
        falseButton.onClick.AddListener(SetFalse);
        trueButton.onClick.AddListener(SetTrue);

        LoadBoolValue();
        ToggleObjects();
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
    }

    public void SetTrue()
    {
        boolValue = true;
        ToggleObjects();
        SaveBoolValue();
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

        // Change the font color based on the boolValue
        if (textMesh != null)
            textMesh.color = boolValue ? onColor : offColor;
    }
}
