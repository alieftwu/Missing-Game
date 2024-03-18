using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class lockBackgroundScript : MonoBehaviour
{
    public keyScript key;
    private string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneToLoad = PlayerPrefs.GetString("LoadScene");
        print("Game Win");
        key.stopKey();
        PlayerPrefs.SetInt(sceneToLoad, 1);
        SceneManager.LoadScene(sceneToLoad);
    }

}
