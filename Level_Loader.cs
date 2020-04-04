using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class Level_Loader : MonoBehaviour
{
    public Animator transition;
    public float trasitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextMap();
        }
    }

    public void LoadNextMap()
    {
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));

    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(trasitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
