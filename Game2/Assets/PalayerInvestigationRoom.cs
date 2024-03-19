using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PalayerInvestigationRoom : MonoBehaviour
{
    public GameObject thoughtBubblePrefab; // Reference to the thought bubble prefab

    private GameObject thoughtBubble; // Reference to the instantiated thought bubble

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject childObject = thoughtBubblePrefab.transform.GetChild(0).gameObject;
        TMP_Text childText = childObject.GetComponent<TMP_Text>();

        if (PlayerPrefs.GetInt("globalState") == 0)
        {
            if (collision.GetComponent<GardenerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Timothy took over Mr. Stone’s estate’s gardening duties last fall after his previous gardner retired.  Timothy is reported to have had many arguments with Mr. Stone regarding plant care and disliked Mr. Stone.";
                PlayerPrefs.SetString("suspect", "gardener");
            }
            else if (collision.GetComponent<ButlerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Johnathan has served as the victim’s butler for over 20 years and enjoyed a pleasant relationship.  After completing his nightly duties, he was the last person to see Mr. Stone.";
                PlayerPrefs.SetString("suspect", "construction");
            }
            else if (collision.GetComponent<ConstructionSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "After a series of electrical issues in the house, Daniel was hired to fix the faulty wiring.  Daniel was hired from a contracting website without any references.  Daniel completed the wiring the day prior to Mr. Stone’s disappearance.";
                PlayerPrefs.SetString("suspect", "butler");
            }
        }

        else if (PlayerPrefs.GetInt("globalState") == 1)
        {
            if (collision.GetComponent<GardenerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Six months ago, Mr. Stone removed his nephew Greyson from his will after Greyson suddenly dropped out of college.  After an angry confrontation at a family reunion, Greyson stopped talking to his previous favorite uncle.";
                PlayerPrefs.SetString("suspect", "gardener");
            }
            else if (collision.GetComponent<ButlerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Timothy took over Mr. Stone’s estate’s gardening duties last fall after his previous gardner retired.  Timothy is reported to have had many arguments with Mr. Stone regarding plant care and disliked Mr. Stone.";
                PlayerPrefs.SetString("suspect", "construction");
            }
            else if (collision.GetComponent<ConstructionSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Samantha has been cleaning Mr. Stone’s house twice a week for five years.  She has a good relationship with all of her clients and a track record of timeliness.  Without notice, Samantha did not show up this week to clean Mr. Stone’s house.";
                PlayerPrefs.SetString("suspect", "butler");
            }
        }
        else if (PlayerPrefs.GetInt("globalState") == 2)
        {
            if (collision.GetComponent<GardenerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Dr. Hurst has lived next to Mr. Stone for a rocky five years.  Mr. Stone is not fond of the frequent and large events Dr. Hurst hosts at his house.  On multiple occasions, Mr. Stone has confronted Dr. Hurst, but the two never reached a resolution.";
                PlayerPrefs.SetString("suspect", "gardener");
            }
            else if (collision.GetComponent<ConstructionSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Mr. and Mrs. Stone have been married for over 50 years, and while this marriage started off happily, things have recently been going downhill. Despite living in the same home, Mrs. Stone was unaware of Mr. Stone's disappearance.";
                PlayerPrefs.SetString("suspect", "construction");
            }
            else if (collision.GetComponent<ButlerSuspect>())
            {
                thoughtBubblePrefab.SetActive(true);
                childText.text = "Johnathan has served as the victim’s butler for over 20 years and enjoyed a pleasant relationship.  After completing his nightly duties, he was the last person to see Mr. Stone.";
                PlayerPrefs.SetString("suspect", "butler");
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<GardenerSuspect>() ||
            collision.GetComponent<ConstructionSuspect>() ||
            collision.GetComponent<ButlerSuspect>())
        {
            print("close text box");
            thoughtBubblePrefab.SetActive(false);
            PlayerPrefs.SetString("suspect", "");
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Save the player's position before loading the new scene

            if (PlayerPrefs.GetInt("globalState") == 0)
            {
                if (PlayerPrefs.GetString("suspect") == "gardener")
                {
                    SceneManager.LoadScene("Win Screen");
                }
                else if (PlayerPrefs.GetString("suspect") == "construction")
                {
                    SceneManager.LoadScene("Loose Screen");
                }
                else if (PlayerPrefs.GetString("suspect") == "butler")
                {
                    SceneManager.LoadScene("Loose Screen");
                }
            }
            else if (PlayerPrefs.GetInt("globalState") == 1)
            {
                if (PlayerPrefs.GetString("suspect") == "gardener")
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
            else if (PlayerPrefs.GetInt("globalState") == 2)
            {
                if (PlayerPrefs.GetString("suspect") == "gardener")
                {
                    SceneManager.LoadScene("Loose Screen");
                }
                else if (PlayerPrefs.GetString("suspect") == "construction")
                {
                    SceneManager.LoadScene("Loose Screen");
                }
                else if (PlayerPrefs.GetString("suspect") == "butler")
                {
                    SceneManager.LoadScene("Win Screen");
                }
            }
        }
    }
}
