using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
   private void Awake()
{
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();

        System.Random r = new System.Random();
        print(r.Next(0, 3));
        PlayerPrefs.SetInt("globalState", r.Next(0, 3));
        print("Global State: " + PlayerPrefs.GetInt("globalState"));
    }
}
