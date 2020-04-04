using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public float time;
    public float time2Spawn;
    public float EventObj_speed = 9f;
    public int EventScore = 0;

    public GameObject mapSpawn;
    public GameObject[] maps;
    public GameObject[] spawnPoints;
    public GameObject[] obstackles;

    RandomMusic musicCtr;
    SceneController sceneCtr;
    
    public Text WarningText;
    public Text Score_board;

    public bool activeGame = false;
    void Start()
    {
        musicCtr = GetComponent<RandomMusic>();
        SetupEvent();
        sceneCtr = GetComponent<SceneController>();        
    }
    void FixedUpdate()
    {
        if (activeGame)
        {
            if (time < time2Spawn)
            {
                time += 0.02f;
            }
            if (time >= time2Spawn)
            {                
                time = 0f;
                int random2 = Random.Range(0, obstackles.Length);
                Instantiate(obstackles[random2], spawnPoints[0].transform.position, Quaternion.identity);
            }
        }
        EventObj_speed += Time.fixedDeltaTime;
        Score_board.text = "Score: " + EventScore + "";
    }
    public void SetupEvent()
    {
        activeGame = true;
        Time.timeScale = 1f;        
        int randomm = Random.Range(0, maps.Length);
        Instantiate(maps[randomm], mapSpawn.transform.position, Quaternion.identity);
        if (randomm == 3)
        {
            musicCtr.PlayRandomNightMusic();
        }
        else
        {
            musicCtr.PlayRandomMusic();
        }
        musicCtr.audioSetting.mute = false;
    }    
    void PrepareNextDimension()
    {
        WarningText.gameObject.SetActive(true);        
        sceneCtr.Invoke("RestartGame", 5f);
    }
}
