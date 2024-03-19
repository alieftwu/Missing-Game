using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvidenceDescription : MonoBehaviour

{
    public GameObject thoughtBubblePrefab; // Reference to the thought bubble prefab
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject childObject = thoughtBubblePrefab.transform.GetChild(0).gameObject;
        TMP_Text childText = childObject.GetComponent<TMP_Text>();

        if (collision.GetComponent<BloodyHammer>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Bloody Hammer";
        }

        else if (collision.GetComponent<Saw>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Saw";
        }
        else if (collision.GetComponent<ConstructionGoggles>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Construction Goggles";
        }
        else if (collision.GetComponent<LandScapeManual>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Landscape Manual";
        }
        else if (collision.GetComponent<WhiteGlove>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "White Glove";
        }
        else if (collision.GetComponent<WateringCan>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Watering Can";
        }
        else if (collision.GetComponent<EmployeeID>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Employee ID";
        }
        else if (collision.GetComponent<HalfBroomstick>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Half of a broom stick....";
        }
        else if (collision.GetComponent<Spade>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Spade";
        }
        else if (collision.GetComponent<WorkerVest>())
        {
            thoughtBubblePrefab.SetActive(true);
            childText.text = "Worker Vest";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.GetComponent<BloodyHammer>() ||
        collision.GetComponent<Saw>() ||
        collision.GetComponent<ConstructionGoggles>() ||
        collision.GetComponent<LandScapeManual>() ||
        collision.GetComponent<WhiteGlove>() ||
        collision.GetComponent<WateringCan>() ||
        collision.GetComponent<EmployeeID>() ||
        collision.GetComponent<HalfBroomstick>() ||
        collision.GetComponent<Spade>() ||
        collision.GetComponent<WorkerVest>())
    {
            print("close text box");
            thoughtBubblePrefab.SetActive(false);
        }
    }
}
