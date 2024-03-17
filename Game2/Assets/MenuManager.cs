using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu: MonoBehaviour {

    public int gamePlayScene;

    public void PlayGame() {
        SceneManager.LoadScene(gamePlayScene);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
