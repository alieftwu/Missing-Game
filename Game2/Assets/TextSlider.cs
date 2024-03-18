using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private Slider slider;
    private AudioSource rainSound;

    void Start()
   {
    slider = GetComponent<Slider>();
    SetNumberText(slider.value);
    FindRainSound(); // Find the "Rain Ambiance Sound" AudioSource
    Load();
    ChangeVolume(); // Ensure volume is set correctly when the scene starts
   }

    public void SetNumberText(float value)
    {
        numberText.text = value.ToString();
    }

    void Update()
    {
        ChangeVolume(); // Update volume in real-time
    }

    public void ChangeVolume()
    {
        if (rainSound != null)
        {
            float normalizedVolume = slider.value / 100f; // Adjust the factor as needed
            rainSound.volume = normalizedVolume; // Adjust volume based on scaled value
            SaveVolume(); // Save the volume setting
        }
    }

    private void FindRainSound()
    {
        GameObject rainSoundObject = GameObject.Find("Rain Ambiance Sound");
        if (rainSoundObject != null)
        {
            rainSound = rainSoundObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("Rain Ambiance Sound GameObject not found in the scene.");
        }
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume", slider.value);
        ChangeVolume(); // Apply the loaded volume
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
        PlayerPrefs.Save();
    }
}
