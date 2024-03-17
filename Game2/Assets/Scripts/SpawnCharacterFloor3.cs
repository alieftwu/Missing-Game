using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterFloor3 : MonoBehaviour
{
   
    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Load player's position from PlayerPrefs if needed
        if (PlayerPrefs.HasKey("PlayerX3") && PlayerPrefs.HasKey("PlayerY3"))
        {
            // Load player's position from PlayerPrefs
            float playerX3 = PlayerPrefs.GetFloat("PlayerX3");
            float playerY3 = PlayerPrefs.GetFloat("PlayerY3");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX3, playerY3);
        }
    }
}
