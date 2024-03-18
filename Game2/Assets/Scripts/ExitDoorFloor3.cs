using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitDoorFloor3 : MonoBehaviour
{
   public AudioClip openDoorSound;
    private bool exitAllowed;
    private string sceneToLoad;
    private AudioSource audioSource;
     private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorTopRightFloor3>())
        {
            sceneToLoad = "Floor3";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorCenter>())
        {
            sceneToLoad = "Floor3";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorMiddleRight>())
        {
            sceneToLoad = "Floor3 middle bottom right connection";
            exitAllowed = true;
        }
        else if (collision.GetComponent<ExitDoorBottomRightFloor3>())
        {
            PlayerPrefs.SetFloat("PlayerXMiddleConnect", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYMiddleConnect", transform.position.y);
            sceneToLoad = "Floor3";
            exitAllowed = true;
        }
        else if(collision.GetComponent<EnterDoorMiddleConnected>())
        {
            audioSource.PlayOneShot(openDoorSound);
            PlayerPrefs.SetFloat("PlayerXMiddleConnect", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYMiddleConnect", transform.position.y);
            PlayerPrefs.SetString("ReturnScene", "Floor3 bottom right secret");
            if (PlayerPrefs.GetInt("Floor3 middle bottom right connection") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 middle bottom right connection");
            }
            else
            {
                sceneToLoad = "Floor3 middle bottom right connection";
            }
            exitAllowed = true;
        }
        else if(collision.GetComponent<ExitDoorMiddle>())
        {
            PlayerPrefs.SetFloat("PlayerXMiddle", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYMiddle", transform.position.y);
            sceneToLoad = "Floor3 bottom right secret";
            exitAllowed = true;
        }
        else if(collision.GetComponent<ExitDoorLeftMiddle>())
        {
            audioSource.PlayOneShot(openDoorSound);
            PlayerPrefs.SetFloat("PlayerXMiddle", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYMiddle", transform.position.y);
            PlayerPrefs.SetString("ReturnScene", "Floor3 middle bottom right connection");
            if (PlayerPrefs.GetInt("Floor3 middle right") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 middle right");
            }
            else
            {
                sceneToLoad = "Floor3 middle right";
            }
            exitAllowed = true;
        }
        else if(collision.GetComponent<ExitDoorLeftToFloor3>())
        {
            PlayerPrefs.SetFloat("PlayerXLeftRoom", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYLeftRoom", transform.position.y);
            sceneToLoad = "Floor3";
            exitAllowed = true;
        }
        else if(collision.GetComponent<ExitDoorMiddleRoom>())
        {
            audioSource.PlayOneShot(openDoorSound);
            PlayerPrefs.SetFloat("PlayerXLeftRoom", transform.position.x);
            PlayerPrefs.SetFloat("PlayerYLeftRoom", transform.position.y);
            PlayerPrefs.SetString("ReturnScene", "Floor3 left");
            if (PlayerPrefs.GetInt("Floor3 left secret") == 0)
            {
                sceneToLoad = "Key Game";
                PlayerPrefs.SetString("LoadScene", "Floor3 left secret");
            }
            else
            {
                sceneToLoad = "Floor3 left secret";
            }
            exitAllowed = true;
        }
        else if(collision.GetComponent<ExitDoorLeftHidden>())
        {
            sceneToLoad = "Floor3 left";
            exitAllowed = true;
        }
    }
     private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ExitDoorTopRightFloor3>() || collision.GetComponent<ExitDoorCenter>()
        || collision.GetComponent<ExitDoorMiddleRight>() || collision.GetComponent<ExitDoorBottomRightFloor3>() ||
        collision.GetComponent<EnterDoorMiddleConnected>() || collision.GetComponent<ExitDoorMiddle>()
        || collision.GetComponent<ExitDoorLeftMiddle>() || collision.GetComponent<ExitDoorLeftToFloor3>()
        || collision.GetComponent<ExitDoorMiddleRoom>() || collision.GetComponent<ExitDoorLeftHidden>())
        {
            exitAllowed = false;
        }
    }
    private void Update() 
    {
        if (exitAllowed && Input.GetKey(KeyCode.Return))
        {
           //Save the player's position before loading the new scene
            //PlayerPrefs.SetFloat("PlayerX2", transform.position.x);
            //PlayerPrefs.SetFloat("PlayerY2", transform.position.y);
            
            //Load the next scene after small delay to play sound
           SceneManager.LoadScene(sceneToLoad);
        }
    }
    
}
