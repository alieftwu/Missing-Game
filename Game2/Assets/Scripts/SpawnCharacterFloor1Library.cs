using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterFloor1Library : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Load player's position from PlayerPrefs if needed
        if (PlayerPrefs.HasKey("PlayerXLibrary") && PlayerPrefs.HasKey("PlayerYLibrary"))
        {
            // Load player's position from PlayerPrefs
            float playerXlib = PlayerPrefs.GetFloat("PlayerXLibrary");
            float playerYlib = PlayerPrefs.GetFloat("PlayerYLibrary");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerXlib, playerYlib);
        }
    }
}
