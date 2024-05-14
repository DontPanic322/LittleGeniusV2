using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter: MonoBehaviour
{
    public char letterName;
    public LetterManager manager;
    public AudioClip clip;

    public void CheckWin()
    {
        if(manager.currentLetter == letterName)
        {
            manager.StartNewTask();
            manager.gameProgress += 1;
            manager.myFX.clip = clip;
            manager.myFX.Play();
        }
    }
}
