using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabKeyScript : MonoBehaviour
{
    public Sprite secondSprite;
    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
    private Sprite originalSprite;
    public KeyCode interactKey = KeyCode.E;
    public Sprite icon;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;

        // Check if the clue has been collected previously and destroy it if necessary
        if (PlayerPrefs.HasKey(gameObject.name) && PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            InteractWithClues();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            if (secondSprite != null)
            {
                spriteRenderer.sprite = secondSprite;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            spriteRenderer.sprite = originalSprite;
        }
    }

    private void InteractWithClues()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Player player = collider.GetComponent<Player>();
                if (player != null)
                {
                    // Mark the clue as collected in PlayerPrefs

                }
            }
            else if (collider.CompareTag("Clue"))
            {
                // Destroy the clue object
                PlayerPrefs.SetInt(gameObject.name, 1);
                print(gameObject.name);
                Destroy(collider.gameObject);
            }
            print("this ran too");
        }
    }
}
