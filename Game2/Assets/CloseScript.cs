using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Description : MonoBehaviour
{
    [SerializeField] GameObject description;

    void Start()
    {
        // Check if the popup has been displayed before
        if (!PlayerPrefs.HasKey("PopupDisplayed"))
        {
            // Display the popup
            description.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Close()
    {
        description.SetActive(false);
        Time.timeScale = 1;

        // Set the flag to indicate that the popup has been displayed
        PlayerPrefs.SetInt("PopupDisplayed", 1);
        PlayerPrefs.Save();
    }
}
