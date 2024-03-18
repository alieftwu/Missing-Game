using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actdeactobj : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("down");
            obj.SetActive(true);
            
        }//end if
    }//end update
}
