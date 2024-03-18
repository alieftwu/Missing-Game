using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoorFloor1 : MonoBehaviour
{
    public AudioClip openDoorSound;
    private AudioSource audioSource;
    private bool exitAllowed;
    private string sceneToLoad;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorLeft>())
        {
            PlayerPrefs.SetFloat("PlayerXLibrary", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYLibrary", transform.position.y);
            sceneToLoad = "Floor 1";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorRight>())
        {
            sceneToLoad = "Floor 1";
            exitAllowed = true;
        }
        else if (collision.GetComponent<EnterSecretLibrary>())
        {
            PlayerPrefs.SetFloat("PlayerXLibrary", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYLibrary", transform.position.y);
            audioSource.PlayOneShot(openDoorSound);
            sceneToLoad = "Book Game";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitToFloor1LeftRoom>())
        {
            sceneToLoad = "Floor1 left";
            exitAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorLeft>() || collision.GetComponent<ExitDoorRight>() || collision.GetComponent<EnterSecretLibrary>()
        || collision.GetComponent<ExitToFloor1LeftRoom>())
        {
            exitAllowed = false;
        }
    }
    private void Update() 
    {
        if (exitAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            //PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            //PlayerPrefs.SetFloat("PlayerY", transform.position.y);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
