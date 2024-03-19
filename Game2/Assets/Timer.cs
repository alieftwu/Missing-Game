using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    [SerializeField] TextMeshProUGUI timerText;
    public static float remainingTime = 80f; // Static variable to hold the remaining time, initially set to 2 minutes
    public GameObject popupPanel; // Reference to the popup panel object

    private bool popupDisplayed = false;

    void Update()
    {

        // Check if the current scene is the main menu scene
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            ResetTimer(); // Reset the timer if the main menu scene is loaded
        }
        else
        {
            // Check if the "Investigation Room - Copy" scene is loaded
            if (SceneManager.GetSceneByName("Investigation Room - Copy").isLoaded)
            {
                // Deactivate the popup panel if it's loaded
                if (popupPanel != null)
                {
                    popupPanel.SetActive(false);
                }
            }

            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (!popupDisplayed)
            {
                remainingTime = 0;
                DisplayPopup(); // Display the popup when timer reaches zero
                popupDisplayed = true;
            }
        }



        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Awake()
    {
        // Ensure only one instance of Timer exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void DisplayPopup()
    {
        // Activate the popup panel
        if (popupPanel != null)
        {
            popupPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Popup panel reference is missing.");
        }
    }

    public void DestroyPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Popup panel reference is missing.");
        }
    }

    public void GoToInvestigation()
    {
        SceneManager.LoadScene("Investigation Room");
    }

    private void ResetTimer()
    {
        remainingTime = 600f; // Reset the remaining time to 2 minutes
    }
}
