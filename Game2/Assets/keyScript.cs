using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    int stop = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    //adjust this to change speed
    float speed = 5f;
    //adjust this to change how high it goes
    float height = 2f;
    // Update is called once per frame
    void Update()
    {
        if (stop == 1)
        {
            float newY = Mathf.Sin(Time.time * speed) * height;
            //set the object's Y to the new calculated Y
            transform.position = new Vector2(transform.position.x, newY);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stop = 2;
            }
        }
        else if (stop == 2)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void stopKey()
    {
        stop = 3;
    }
}
