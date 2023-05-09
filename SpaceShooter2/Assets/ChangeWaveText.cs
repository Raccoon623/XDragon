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
            waveText.text = "Boss";
            // You may want to add code here to trigger the boss battle
            // once the text has changed.
        }
    }
}