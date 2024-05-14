using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public float levelTime;
    private float timeCurrent;
    private int sceneIndex;
    private int starCount;

    public GameObject winInterface;
    public GameObject loseInterface;

    private void Start()
    {
        timer.time = levelTime;
    }

    private void Update()
    {
        if (timer.time <= 0)
        {
            loseInterface.SetActive(true);
        }
    }

    public void Winning()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        timeCurrent = timer.time;

        if(timeCurrent/levelTime >= 0.8)
            starCount = 3;
        else if (timeCurrent / levelTime < 0.8 && timeCurrent / levelTime >= 0.6)
            starCount = 2;
        else if (timeCurrent / levelTime < 0.6 && timeCurrent / levelTime >= 0.4)
            starCount = 1;
        else if (timeCurrent / levelTime <0.4)
            starCount = 0;

        PlayerPrefs.SetInt("Stars_" + sceneIndex, starCount);
        PlayerPrefs.Save();
        winInterface.SetActive(true);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void NextLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex+1);
    }

    public void RestartLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
