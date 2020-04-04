using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGround : MonoBehaviour
{
    miniGameController gameCtr;
    public GameObject[] spawnEffectPos;
    GameObject spawnGroundEffect;
    bool spawned = false;    
    private void Start()
    {
        gameCtr = GameObject.Find("miniGameController").GetComponent<miniGameController>();
        spawnGroundEffect = gameCtr.spawnGroundEffect;
    }    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && spawned == false)
        {
            int random1 = Random.Range(0, 2);
            int random2 = Random.Range(gameCtr.minRandom, gameCtr.maxRandom);
            Instantiate(spawnGroundEffect, spawnEffectPos[random1].transform.position, Quaternion.identity);            
            if (random1 == 0)
            {
                Instantiate(gameCtr.Grounds_left[random2], transform.position, Quaternion.identity);
            }
            else if (random1 == 1)
            {
                Instantiate(gameCtr.Grounds_right[random2], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }
}
