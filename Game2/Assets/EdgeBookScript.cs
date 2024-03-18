using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.IK;

public class EdgeBookScript : MonoBehaviour
{

    public ArrowScript arrow;


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
        arrow.stopKey();
        SceneManager.LoadScene("Floor1 left");

    }
}
