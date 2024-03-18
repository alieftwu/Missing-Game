using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CenterBookScript : MonoBehaviour
{
    // Start is called before the first frame update

    public ArrowScript arrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Game Win");
        arrow.stopKey();
        SceneManager.LoadScene("Floor 1 lib secret");
    }
}
