using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Image pausePanel;
    RandomMusic musicCtr;
    private void Start()
    {
        musicCtr = GetComponent<RandomMusic>();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        pausePanel.gameObject.SetActive(true);
        musicCtr.audioSetting.pitch = 0f;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pausePanel.gameObject.SetActive(false);
        musicCtr.audioSetting.pitch = 1f;
        Time.timeScale = 1f;
    }
}
