using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    float time = 7.2f;
    float time2Spawn = 7.2f;    
        
    public GameObject mapSpawn;
    public GameObject[] maps;
    public GameObject[] spawnPoints;
    public GameObject[] obstackles;
    public GameObject setupGround;  //setupGround Prefab

    public AudioClip[] musics;
    public AudioClip[] nightMusics;
    public AudioSource soundSetting;

    public Image pausePanel;    
    public Text WarningText;

    public bool activeGame = false;

    //Data needs to be saved down here
    public float money = 0f;
    void Start()
    {        
        SetupEasyMode();
        soundSetting = GetComponent<AudioSource>();        
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
    }
    public void SetupEasyMode()
    {
        activeGame = true;
        Time.timeScale = 1f;
        soundSetting.mute = false;        
        //Invoke("PrepareNextDimension", 55f);
        int randomm = Random.Range(0, maps.Length);
        Instantiate(maps[randomm], mapSpawn.transform.position, Quaternion.identity);
        if (randomm == 3)
        {
            PlayRandomNightMusic();
        }
        else
        {
            PlayRandomMusic();
        }
    }
    public void PlayRandomMusic()
    {
        int rand = Random.Range(0, musics.Length);
        soundSetting.clip = musics[rand];
        soundSetting.Play();
    }
    public void PlayRandomNightMusic()
    {
        int rand = Random.Range(0, nightMusics.Length);
        soundSetting.clip = nightMusics[rand];
        soundSetting.Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
    void PrepareNextDimension()
    {
        WarningText.gameObject.SetActive(true);
        Invoke("RestartGame", 5f);
    }    
}
