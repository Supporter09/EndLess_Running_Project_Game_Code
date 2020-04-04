using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs : MonoBehaviour
{
    float time = 10f;
    float speed = 7f;
    void Start()
    {
        Destroy(this.gameObject, time);
    }    
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
