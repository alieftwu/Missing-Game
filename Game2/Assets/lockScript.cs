using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lockScript : MonoBehaviour
{
    public keyScript key;
    private string sceneToLoad;
    public int OMLNumber;

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
        print("Game Failed");
        key.stopKey();
        sceneToLoad = PlayerPrefs.GetString("ReturnScene");
        SceneManager.LoadScene(sceneToLoad);
    }




}
