using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObj : MonoBehaviour
{
    public float time2Destroy;    
    public GameObject[] emoji;
    EventController gameCtr;
    void Start()
    {
        Destroy(this.gameObject, time2Destroy);
        gameCtr = GameObject.Find("EventController").GetComponent<EventController>();
    }
       
    void Update()
    {
        transform.Translate(Vector2.left * gameCtr.EventObj_speed * Time.deltaTime);        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int rand = Random.Range(0, emoji.Length);
        Instantiate(emoji[rand], transform.position, Quaternion.identity);        
        Destroy(this.gameObject);
    }
}
