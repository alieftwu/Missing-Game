using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterLeftRoom : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; 
    private void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // Load player's position from PlayerPrefs if needed
            if (PlayerPrefs.HasKey("PlayerXLeftRoom") && PlayerPrefs.HasKey("PlayerYLeftRoom"))
                {
                // Load player's position from PlayerPrefs
                float playerX6 = PlayerPrefs.GetFloat("PlayerXLeftRoom");
                float playerY6 = PlayerPrefs.GetFloat("PlayerYLeftRoom");

                // Set the player's position
                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX6, playerY6);
                }
            
        }
}
