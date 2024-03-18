using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoorFloor2 : MonoBehaviour
{
    public AudioClip openDoorSound;
    private bool enterAllowed;
    private string sceneToLoad;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(openDoorSound != null)
        {
            audioSource.PlayOneShot(openDoorSound);
        }
        if (collision.GetComponent<BottomLeftDoor>())
        {
            if (PlayerPrefs.GetInt("Floor2 bottom left Secret") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor2 bottom left Secret");
            }
            else
            {
                sceneToLoad = "Floor2 bottom left Secret";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<TopLeftDoor>())
        {
            if (PlayerPrefs.GetInt("Floor2 Top left") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor2 Top left");
            }
            else
            {
                sceneToLoad = "Floor2 Top left";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<TopRightDoor>())
        {
            if (PlayerPrefs.GetInt("Floor 2 top right") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor 2 top right");
            }
            else
            {
                sceneToLoad = "Floor 2 top right";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<SideDoorBottomRight>())
        {
            if (PlayerPrefs.GetInt("Floor2 bottom right") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor2 bottom right");
            }
            else
            {
                sceneToLoad = "Floor2 bottom right";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorBottomStairs>())
        {
            sceneToLoad = "Floor 1";
            enterAllowed = true;
        }
        else if (collision.GetComponent<StairsToFloor3>())
        {
            sceneToLoad = "Floor3";
            enterAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BottomLeftDoor>() || collision.GetComponent<TopLeftDoor>() || collision.GetComponent<TopRightDoor>()
        || collision.GetComponent<SideDoorBottomRight>() || collision.GetComponent<ExitDoorBottomStairs>() || collision.GetComponent<StairsToFloor3>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            PlayerPrefs.SetFloat("PlayerX2", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY2", transform.position.y);

            //Load the next scene after small delay to play sound
            PlayerPrefs.SetString("ReturnScene", "Floor2");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
    
    
