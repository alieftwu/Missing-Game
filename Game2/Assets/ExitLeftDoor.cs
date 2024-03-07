using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLeftDoor : MonoBehaviour
{
    private bool exitAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorLeft>())
        {
            sceneToLoad = "Floor 1";
            exitAllowed = true;
        }
    }
    private void Update() 
    {
        if (exitAllowed && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
