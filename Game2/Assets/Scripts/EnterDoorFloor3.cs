using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterDoorFloor3 : MonoBehaviour
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
        if (collision.GetComponent<ClosedDoorBottomRight>())
        {
            audioSource.PlayOneShot(openDoorSound);
            sceneToLoad = "Floor3 bottom right secret";
            enterAllowed = true;
        }
        else if(collision.GetComponent<ClosedDoorCenter>())
        {
            audioSource.PlayOneShot(openDoorSound);
            sceneToLoad = "Floor3 center";
            enterAllowed = true; 
        }
        else if(collision.GetComponent<ClosedDoorTopRight>())
        {
            audioSource.PlayOneShot(openDoorSound);
        }
        else if(collision.GetComponent<ClosedDoorMiddleRight>())
        {
            audioSource.PlayOneShot(openDoorSound);
            sceneToLoad = "Floor3 top right";
            enterAllowed = true;
        }
        else if(collision.GetComponent<ClosedDoorLeft>())
        {
            audioSource.PlayOneShot(openDoorSound);
            sceneToLoad = "Floor3 left";
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
           SceneManager.LoadScene(sceneToLoad);
        }
    }
}
