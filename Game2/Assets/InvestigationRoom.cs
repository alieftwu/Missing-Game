using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InvestigationRoom : MonoBehaviour
{
    public GameObject menuOverlay;
    public KeyCode toggleMenuKey = KeyCode.Escape;

    private void Start()
    {
        // Hide the menu overlay at the beginning
        menuOverlay.SetActive(false);
    }

    public void ToggleMenu()
    {
        if (Input.GetKeyDown(toggleMenuKey))
        {
            // Toggle the visibility of the menu overlay
            menuOverlay.SetActive(!menuOverlay.activeSelf);
        }
    }

    public void GoToInvestigationRoom()
    {
        // Load the investigation room scene
        SceneManager.LoadScene("Investigation Room - Copy");
    }
}
