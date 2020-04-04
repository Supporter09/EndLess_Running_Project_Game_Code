using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float speed;
    bool goLeft = true;
    public GameObject dir;    
    void Update()
    {
        if (goLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);            
            Quaternion dirr = Quaternion.Euler(0, 0, 45);
            dir.transform.rotation = dirr;
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            Quaternion dirr = Quaternion.Euler(0, 0, -45);
            dir.transform.rotation = dirr;
        }
    }
    public void ChangeDirection()
    {
        bool changed = false;
        if (goLeft && changed == false)
        {
            goLeft = false;
            changed = true;
        }
        else if (goLeft == false && changed == false)
        {
            goLeft = true;
            changed = true;
        }
    }
}
