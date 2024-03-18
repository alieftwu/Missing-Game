using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    int stop = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    //adjust this to change speed
    float speed = 3f;
    //adjust this to change how high it goes
    float width = 5f;
    // Update is called once per frame
    void Update()
    {
        if (stop == 1)
        {
            float newX = Mathf.Sin(Time.time * speed) * width;
            //set the object's Y to the new calculated Y
            transform.position = new Vector2(newX, transform.position.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stop = 2;
            }
        }
        else if (stop == 2)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    public void stopKey()
    {
        stop = 3;
    }
}
