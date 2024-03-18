using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour {
    public static event Action Moveobj;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Moveobj?.Invoke();
        }//end if
    }//end update
}//end eventmanager
