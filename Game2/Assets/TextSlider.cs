using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public AudioSource rainSound;
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);
        Load();

    }
    public void SetNumberText(float value) {
        numberText.text = value.ToString();
    }

    //code for volume change

    void Update()
    {
        ChangeVolume(); // Update volume in real-time
    }


    public void ChangeVolume(){
        float normalizedVolume = slider.value / 100f; // Adjust the factor as needed
        rainSound.volume = normalizedVolume; // Adjust volume based on scaled value
    }

    private void Load(){
        slider.value = PlayerPrefs.GetFloat("musicVolume");
        ChangeVolume(); // Apply the loaded volume

    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", slider.value);
        PlayerPrefs.Save();

    }

}
