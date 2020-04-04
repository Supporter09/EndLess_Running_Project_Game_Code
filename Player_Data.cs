using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // This is where you make variables to save data from your player.
    public float[] position;
    public float score;
    public float money;
    public bool musicSet; //Music on/off
    public PlayerData (Player player)
    {
        //We take player data here so feel free.
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.x;
        position[2] = player.transform.position.x;
    }   
}
