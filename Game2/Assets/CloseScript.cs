using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Description : MonoBehaviour
{
    [SerializeField] GameObject description;

    public void Start()
    {
        int buttonPressed = PlayerPrefs.GetInt("ButtonPressed");
        Debug.Log("ButtonPressed value: " + buttonPressed);

        // Check if the popup has been displayed before
        if (PlayerPrefs.GetInt("ButtonPressed") == 1)
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
        PlayerPrefs.DeleteKey("ButtonPressed");
        PlayerPrefs.Save();
    }
}
