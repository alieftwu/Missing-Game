using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenerSuspect : MonoBehaviour
{
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite thirdSprite;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        firstSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("globalState") == 0)
        {
            spriteRenderer.sprite = firstSprite;
        }
        else if (PlayerPrefs.GetInt("globalState") == 1)
        {
            spriteRenderer.sprite = secondSprite;
        }
        else if (PlayerPrefs.GetInt("globalState") == 2)
        {
            spriteRenderer.sprite = thirdSprite;
        }

    }
}
