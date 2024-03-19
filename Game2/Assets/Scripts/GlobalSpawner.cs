using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpawner : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("globalState") == 0)
        {
            obj1.SetActive(true);
        }else if(PlayerPrefs.GetInt("globalState") == 1)
        {
            obj2.SetActive(true);
        }else if(PlayerPrefs.GetInt("globalState") == 2)
        {
            obj3.SetActive(true); 
        }//end else if
}//end update4
}//end update
