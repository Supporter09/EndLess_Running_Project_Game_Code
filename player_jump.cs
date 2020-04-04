using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_jump : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spr;
    GameController gameCtr;
    EventController eventCtr;
    RandomMusic musicCtr;
    public Animator camShake;

    public bool pressJump = false;
    public bool isEvent;
    bool jumpAllowed = true;

    public float jumpForce;

    public GameObject splashPrefab;
    public GameObject diePrefab;

    public Image endPanel;
    public Sprite[] playerColors;

    public AudioClip gameOverSound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();        
        int rand = Random.Range(0, playerColors.Length);
        spr.sprite = playerColors[rand];
        if (isEvent)
        {
            eventCtr = GameObject.Find("EventController").GetComponent<EventController>();
            musicCtr = GameObject.Find("EventController").GetComponent<RandomMusic>();
        }
        else
        {
            gameCtr = GameObject.Find("GameController").GetComponent<GameController>();
        }
    }    
    void FixedUpdate()
    {
        if (pressJump == true)
        {
            jumpAllowed = false;            
            rb.AddForce(Vector2.up * jumpForce);            
            pressJump = false;
        }        
    }
    public void CheckJumpButton()
    {
        if (jumpAllowed)
        {
            pressJump = true;
        }
    }    
    void PlayerDie()
    {        
        if (isEvent == false)
        {
            gameCtr.soundSetting.clip = gameOverSound;
            gameCtr.soundSetting.Play();
        }
        else
        {
            musicCtr.audioSetting.clip = gameOverSound;
            musicCtr.audioSetting.Play();
        }
        Instantiate(diePrefab, transform.position, Quaternion.identity);
        Time.timeScale = 0.1f;
        Invoke("StopGame", 0.3f);        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            Instantiate(splashPrefab, transform.position, Quaternion.identity);
            jumpAllowed = true;            
        }
        if (collision.collider.CompareTag("die"))
        {
            camShake.SetTrigger("shake");
            Invoke("PlayerDie", 0.05f);
        }
        if (collision.collider.CompareTag("ground"))
        {
            jumpAllowed = true;            
        }
        if (isEvent)
        {
            if (spr.sprite == playerColors[0])
            {
                if (collision.collider.gameObject.name != "BlueSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    PlayerDie();
                }
                else if (collision.collider.gameObject.name == "BlueSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    eventCtr.EventScore += 1;
                }
            }
            else if (spr.sprite == playerColors[1])
            {
                if (collision.collider.gameObject.name != "GreenSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    PlayerDie();
                }
                else if (collision.collider.gameObject.name == "GreenSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    eventCtr.EventScore += 1;
                }
            }
            else if (spr.sprite == playerColors[2])
            {
                if (collision.collider.gameObject.name != "RedSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    PlayerDie();
                }
                else if (collision.collider.gameObject.name == "RedSquare2(Clone)" && collision.collider.CompareTag("enemy"))
                {
                    eventCtr.EventScore += 1;
                }
            }
        }
    }
    void StopGame()
    {
        endPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}