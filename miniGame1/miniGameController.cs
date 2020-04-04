using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class miniGameController : MonoBehaviour
{
    public GameObject[] Grounds_left;
    public GameObject[] Grounds_right;    
    public GameObject spawnGroundEffect;
    [HideInInspector]
    public int minRandom;
    [HideInInspector]
    public int maxRandom;

    RandomMusic musicCtr;    

    float time = 0f;
    void Start()
    {        
        minRandom = 0;
        maxRandom = 0;        
    }    
    void FixedUpdate()
    {        
        if (time == 0)
        {
            musicCtr = GetComponent<RandomMusic>();
            musicCtr.PlayRandomNightMusic();
        }
        time += 0.02f;
        if (time > 3f)
        {
            minRandom = 1;
            maxRandom = 2;
        }
        if (time > 120f)
        {
            musicCtr.PlayRandomNightMusic();
            time = 4f;
        }
    }    
}
