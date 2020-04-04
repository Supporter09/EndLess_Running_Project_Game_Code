using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public float time2Destroy;
    float speed = 7;
    void Start()
    {
        Destroy(this.gameObject, time2Destroy);
    }    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }    
}
