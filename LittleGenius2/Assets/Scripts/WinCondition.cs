using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class WinCondition : MonoBehaviour
{
    public GameManager manager;

    public int levelProgress;
    public int numberToWin;

    void Update()
    {
        CheckForWin();
    }

    public void CheckForWin()
    {
        if(levelProgress == numberToWin)
        {
            manager.Winning();
        }
    }
}
