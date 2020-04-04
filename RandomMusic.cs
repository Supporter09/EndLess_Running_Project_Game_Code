using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioSource audioSetting;
    public AudioClip[] musics;
    public AudioClip[] nightMusics;
    void Awake()
    {
        audioSetting = GetComponent<AudioSource>();        
    }
    public void PlayRandomMusic()
    {
        int rand = Random.Range(0, musics.Length);
        audioSetting.clip = musics[rand];
        audioSetting.Play();
    }
    public void PlayRandomNightMusic()
    {        
        int rand2 = Random.Range(0, nightMusics.Length);        
        audioSetting.clip = nightMusics[rand2];
        audioSetting.Play();
    }
}
