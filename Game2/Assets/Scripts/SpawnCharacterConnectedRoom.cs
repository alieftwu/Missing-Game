using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterConnectedRoom : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Load player's position from PlayerPrefs if needed
        if (PlayerPrefs.HasKey("PlayerXMiddleConnect") && PlayerPrefs.HasKey("PlayerYMiddleConnect"))
        {
            // Load player's position from PlayerPrefs
            float playerX4 = PlayerPrefs.GetFloat("PlayerXMiddleConnect");
            float playerY4 = PlayerPrefs.GetFloat("PlayerYMiddleConnect");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX4, playerY4);
        }
    }
}
