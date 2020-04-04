using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAdventure : MonoBehaviour
{
    SpriteRenderer spr;
    RandomMusic musicCtr;
    public Animator camShake;

    gameCtrl gameCtr;
    public GameObject leftPos;
    public GameObject rightPos;
    public GameObject splashPrefab;

    public Image endPanel;
    public Sprite[] playerColors;

    public AudioClip gameOverSound;

    public float speed;

    bool isLeft = true;
    private void Start()
    {
        gameCtr = GameObject.Find("GameController").GetComponent<gameCtrl>();
        spr = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, playerColors.Length);
        spr.sprite = playerColors[rand];
        musicCtr = GameObject.Find("GameController").GetComponent<RandomMusic>();
    }
    void Update()
    {
        if (gameCtr.activedGame)
        {
            if (isLeft)
            {
                transform.position = Vector2.MoveTowards(transform.position, leftPos.transform.position, speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, rightPos.transform.position, speed);
            }
        }
    }
    void PlayerDie()
    {
        musicCtr.audioSetting.clip = gameOverSound;
        musicCtr.audioSetting.Play();
        Instantiate(splashPrefab, transform.position, Quaternion.identity);
        Time.timeScale = 0.1f;
        Invoke("StopGame", 0.3f);
    }
    void StopGame()
    {
        endPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TapScreen()
    {
        if (gameCtr.activedGame)
        {
            bool changed = false;
            if (isLeft && changed == false)
            {
                isLeft = false;
                changed = true;
            }
            else if (isLeft == false && changed == false)
            {
                isLeft = true;
                changed = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            camShake.SetTrigger("shake");
            Invoke("PlayerDie", 0.05f);
        }
    }
}
