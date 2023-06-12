using UnityEngine;
using TMPro;

public class FontColorChanger : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Color targetColor;

    public void ChangeFontColor()
    {
        // Set the color with alpha value of 255
        targetColor.a = 1f;
        textMesh.color = targetColor;
    }
}