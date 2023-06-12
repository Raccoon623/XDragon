using UnityEngine;
using TMPro;

public class ChangeWaveText : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 30f)
        {
            waveText.text = "Wave 2";
        }

        if (timer >= 60f)
        {
            waveText.text = "Wave 3";
            // You may want to add code here to trigger the boss battle
            // once the text has changed.
        }
        
        if (timer >= 90f)
        {
            waveText.text = "UFO";
            // You may want to add code here to trigger the boss battle
            // once the text has changed.
        }

    }
}