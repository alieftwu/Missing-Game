using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalayerInvestigationRoom : MonoBehaviour
{
    public GameObject thoughtBubblePrefab; // Reference to the thought bubble prefab
    private GameObject thoughtBubble; // Reference to the instantiated thought bubble

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<GardenerSuspect>())
        {
            print("Gardener Suspect");
            PlayerPrefs.SetString("suspect", "gardener");
        }
        else if (collision.GetComponent<ConstructionSuspect>())
        {
            print("Construction Suspect");
            PlayerPrefs.SetString("suspect", "construction");
        }
        else if (collision.GetComponent<ButlerSuspect>())
        {
            print("BUtler Suspect");
            PlayerPrefs.SetString("suspect", "butler");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GardenerSuspect>() ||
            collision.GetComponent<ConstructionSuspect>() ||
            collision.GetComponent<ButlerSuspect>())
        {
            print("close text box");
            PlayerPrefs.SetString("suspect", "");
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Save the player's position before loading the new scene
            if(PlayerPrefs.GetString("suspect") == "gardener")
            {
                SceneManager.LoadScene("Loose Screen");
            }
            else if (PlayerPrefs.GetString("suspect") == "construction")
            {
                SceneManager.LoadScene("Win Screen");
            }
            else if (PlayerPrefs.GetString("suspect") == "butler")
            {
                SceneManager.LoadScene("Loose Screen");
            }

        }
    }
}
