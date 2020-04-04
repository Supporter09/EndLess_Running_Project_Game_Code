using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Put variables here!
    

    //


    // This is SavePlayer() function you can set when it work like: GameOver, CLick a Button, Autosave after 10 sec, ....
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    // This is LoadPlayer() function you can set when it work like: GameOver, CLick a Button, Autosave after 10 sec, ....
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }
}
