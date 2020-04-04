using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string MainGame;
    public string ScoreMode;
    public string AdventureMode;
    int gameMode_num = 1;

    public Text Text_GameMode;
        
    void Update()
    {
        switch (gameMode_num)
        {            
            case 1:
                Text_GameMode.text = MainGame;
                break;
            case 2:
                Text_GameMode.text = ScoreMode;
                break;
            case 3:
                Text_GameMode.text = AdventureMode;
                break;
        }
    }
    public void LeftButton()
    {
        if (gameMode_num > 1)
        {
            gameMode_num -= 1;
        }
    }
    public void RightButton()
    {
        if (gameMode_num < 3)
        {
            gameMode_num += 1;
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(gameMode_num);
    }    
}
