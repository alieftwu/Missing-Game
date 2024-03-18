using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoor : MonoBehaviour
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
        if (collision.GetComponent<RightDoor>())
        {
            if (PlayerPrefs.GetInt("Floor 1 right") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor 1 right");
            }
            else
            {
                sceneToLoad = "Floor 1 right";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<LeftDoor>())
        {
            if (PlayerPrefs.GetInt("Floor1 left") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor1 left");
            }
            else
            {
                sceneToLoad = "Floor1 left";
            }
            enterAllowed = true;
        }
        else if (collision.GetComponent<BottomStairs>())
        {
            sceneToLoad = "Floor2";
            enterAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<RightDoor>() || collision.GetComponent<LeftDoor>() || collision.GetComponent<BottomStairs>() || collision.GetComponent<ClosedDoorTop>())
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            PlayerPrefs.SetFloat("PlayerX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", transform.position.y);

            PlayerPrefs.SetString("ReturnScene", "Floor 1");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
    
