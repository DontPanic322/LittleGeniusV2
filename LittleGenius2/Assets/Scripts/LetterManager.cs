using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{
    public Letter[] letters;
    public Sprite[] taskImages;
    private List<Sprite> avaibleTasks;
    public Image letterTask;

    public char currentLetter;

    public int gameProgress = 0;
    public GameManager manager;
    private int currentTask=0;
    public AudioSource myFX;
    
    private void Start()
    {
        avaibleTasks = new List<Sprite>(taskImages);
        StartNewTask();
    }

    private void Update()
    {
        if(gameProgress == 10)
        {
            manager.Winning();
        }
    }

    public void StartNewTask()
    {
        if (currentTask != letters.Length)
        {
            currentLetter = letters[currentTask].letterName;
            letterTask.sprite = taskImages[currentTask];

            currentTask++;
        }
    }

}
