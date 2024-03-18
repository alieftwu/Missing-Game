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
        }
        else if (collision.GetComponent<ConstructionSuspect>())
        {
            print("Construction Suspect");
        }
        else if (collision.GetComponent<ButlerSuspect>())
        {
            print("BUtler Suspect");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GardenerSuspect>() ||
            collision.GetComponent<ConstructionSuspect>() ||
            collision.GetComponent<ButlerSuspect>())
        {
            print("close text box");
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Save the player's position before loading the new scene
        }
    }
}
