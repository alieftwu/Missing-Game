using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu: MonoBehaviour {



    public void PlayGame() {
        PlayerPrefs.SetInt("ButtonPressed", 1);
        PlayerPrefs.Save();
        Debug.Log("ButtonPressed set to 1");
        SceneManager.LoadScene("Floor 1");
        Time.timeScale = 0;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
