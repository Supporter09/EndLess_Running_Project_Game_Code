using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    
    public float money;
    public bool musicSet; //Music on/off
    public GameData(GameController gameCtr)
    {
        money = (int)gameCtr.money;
    }
}
