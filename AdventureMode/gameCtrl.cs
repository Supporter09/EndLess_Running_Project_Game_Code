using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCtrl : MonoBehaviour //Adventure Mode
{
    RandomMusic musicCtr;
    GameObject player;    
    public GameObject[] obs;

    float spawnTime = -2.5f;
    public float speed;

    [HideInInspector]
    public bool activedGame = false;
    void Start()
    {
        player = GameObject.Find("Player");
        player.gameObject.SetActive(false);
        musicCtr = GetComponent<RandomMusic>();
        musicCtr.PlayRandomMusic();
        Invoke("StartGame", 3f);
    }    
    void FixedUpdate()
    {
        if (spawnTime < 0.5f)
        {
            spawnTime += 0.02f;
        }
        else
        {
            SpawnObs();
            spawnTime = 0f;
        }
    }
    void SpawnObs()
    {
        float rand = Random.Range(-8f, 8f);
        Vector2 pos = new Vector2(rand, -10);
        int rand2 = Random.Range(0, obs.Length);
        Instantiate(obs[rand2], pos, Quaternion.identity);
    }
    void StartGame()
    {
        activedGame = true;
        player.gameObject.SetActive(true);
    }    
}
