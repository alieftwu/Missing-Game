using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
        SetNumberText(slider.value);

    }
    public void SetNumberText(float value) {
        numberText.text = value.ToString();
    }

    //code for volume change
    /*
    public void ChangeVolume(){
        AudioListeners.volume = slider.value;
    }

    private void Load(){
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }
    */
}