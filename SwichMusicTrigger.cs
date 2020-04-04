using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichMusicTrigger : MonoBehaviour
{
    public AudioClip newtrack;
    //private AudioManager theAM;

    // Start is called before the first frame update
    void Start()
    {
        //theAM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(newtrack != null)
            {

            }
            //theAM.ChangeBGM(newtrack);
        }
    }
}
