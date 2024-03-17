using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterMiddleRoom : MonoBehaviour
{
    [SerializeField] private GameObject playerObject; 
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerPrefs.HasKey("PlayerXMiddle") && PlayerPrefs.HasKey("PlayerYMiddle"))
        {
            // Load player's position from PlayerPrefs
            float playerX5 = PlayerPrefs.GetFloat("PlayerXMiddle");
            float playerY5 = PlayerPrefs.GetFloat("PlayerYMiddle");

            // Set the player's position
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(playerX5, playerY5);
        }
    }
}
