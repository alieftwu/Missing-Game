using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoorFloor3 : MonoBehaviour
{
    public GameObject thoughtBubblePrefab; // Reference to the thought bubble prefab
    private GameObject thoughtBubble; // Reference to the instantiated thought bubble
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
        if (collision.GetComponent<ClosedDoorBottomRight>())
        {
            audioSource.PlayOneShot(openDoorSound);
            if (PlayerPrefs.GetInt("Floor3 bottom right secret") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 bottom right secret");
            }
            else
            {
                sceneToLoad = "Floor3 bottom right secret";
            }
            enterAllowed = true;
        }
        else if(collision.GetComponent<ClosedDoorCenter>())
        {
            audioSource.PlayOneShot(openDoorSound);
            if (PlayerPrefs.GetInt("Floor3 center") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 center");
            }
            else
            {
                sceneToLoad = "Floor3 center";
            }
            enterAllowed = true; 
        }
        else if(collision.GetComponent<ClosedDoorTopRight>())
        {
            thoughtBubble = Instantiate(thoughtBubblePrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            thoughtBubble.transform.SetParent(collision.transform);
            audioSource.PlayOneShot(openDoorSound);
        }
        else if(collision.GetComponent<ClosedDoorMiddleRight>())
        {
            audioSource.PlayOneShot(openDoorSound);
            if (PlayerPrefs.GetInt("Floor3 top right") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 top right");
            }
            else
            {
                sceneToLoad = "Floor3 top right";
            }
            enterAllowed = true;
        }
        else if(collision.GetComponent<ClosedDoorLeft>())
        {
            audioSource.PlayOneShot(openDoorSound);
            if (PlayerPrefs.GetInt("Floor3 left") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 left");
            }
            else
            {
                sceneToLoad = "Floor3 left";
            }
            enterAllowed = true;
        }
        else if(collision.GetComponent<BackToFloor2>())
        {
            sceneToLoad = "Floor2";
            enterAllowed = true;
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<ClosedDoorBottomRight>() || collision.GetComponent<ClosedDoorCenter>() || collision.GetComponent<ClosedDoorTopRight>() ||
        collision.GetComponent<ClosedDoorMiddleRight>() || collision.GetComponent<ClosedDoorLeft>() || collision.GetComponent<BackToFloor2>())
        {
            // Remove the thought bubble when the player moves away from the door
            Destroy(thoughtBubble);
            enterAllowed = false;
        }
    }
    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.Return))
        {
            //Save the player's position before loading the new scene
            PlayerPrefs.SetFloat("PlayerX3", transform.position.x);
            PlayerPrefs.SetFloat("PlayerY3", transform.position.y);

            //Load the next scene after small delay to play sound
            PlayerPrefs.SetString("ReturnScene", "Floor3");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
