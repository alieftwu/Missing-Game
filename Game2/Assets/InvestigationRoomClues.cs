using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InvestigationRoomClues : MonoBehaviour
{
    public Sprite secondSprite;
    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
    private Sprite originalSprite;
    public KeyCode interactKey = KeyCode.E;
    public CollectableType type;
    public Sprite icon;




    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;

        print(PlayerPrefs.GetInt(gameObject.name));
        print(gameObject.name);

    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            InteractWithClues();
        }

        if (PlayerPrefs.GetInt(gameObject.name) == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
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

            }

        }
    }
}
