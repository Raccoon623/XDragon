using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timeText;
    public float countdownTime = 10f;

    private float currentTime = 0f;

    void Start()
    {
        currentTime = countdownTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        timeText.text = Mathf.Round(currentTime).ToString();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timeText.text = "UFO!";
            //Do whatever you need to do when the timer reaches 0
        }
    }
}