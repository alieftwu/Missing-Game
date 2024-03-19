using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarForClueLayouts : MonoBehaviour
{
    public static int globalVar;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random();
        globalVar = r.Next(0,3);
        //globalVar = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GV " + globalVar);
    }
}
