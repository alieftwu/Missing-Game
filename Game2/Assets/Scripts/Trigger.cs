using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject obj;
    
    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("Enter");
    }//end enter

    void OnTriggerStay2D(Collider2D collider){
        Debug.Log("stay");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("down");
            obj.SetActive(true);
        }//end if
        }//end stay
}//end Trigger
