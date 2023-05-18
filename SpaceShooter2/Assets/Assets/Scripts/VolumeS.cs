using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeS : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Set the slider value to the current volume
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        // Set the AudioListener volume to the value of the slider
        AudioListener.volume = volume;
    }
}