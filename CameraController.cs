using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public SpriteRenderer image;
    void Start()
    {
        //Camera.main.orthographicSize = image.bounds.size.y / 2;
        Camera.main.orthographicSize = image.bounds.size.x * Screen.height / Screen.width * 0.5f;
    }
}
