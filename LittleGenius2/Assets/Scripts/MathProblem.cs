using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathProblem : MonoBehaviour
{
    public Image firstNumber;
    public Image secondNumber;

    public TextMeshProUGUI answerOneText;
    public TextMeshProUGUI answerTwoText;

    public List<Sprite> sprites;

    private int answerOne, answerTwo;
    private int randomFirstNumber, randomSecondNumber;
    private int rightButtonIndex;

    public AudioSource myFX;
    public AudioClip wrongFX, rightFX;

    private int levelProgress;

    public GameManager gameManager;

    private void Start()
    {
        DisplayMathProblem();
    }

    private void Update()
    {
        if (levelProgress == 4) 
        {
            gameManager.Winning();
        }
    }

    public void DisplayMathProblem()
    {
        randomFirstNumber = Random.Range(0, sprites.Count);
        randomSecondNumber = Random.Range(0, sprites.Count);

        answerOne = randomFirstNumber + randomSecondNumber;

        firstNumber.sprite = sprites[randomFirstNumber];
        secondNumber.sprite = sprites[randomSecondNumber];

        do
        {
            answerTwo = Random.Range(0, sprites.Count);
        } while (answerTwo == answerOne);

        if(Random.Range(0, 2) == 0)
        {
            answerOneText.text = answerOne.ToString();
            answerTwoText.text = answerTwo.ToString();
            rightButtonIndex = 0;
        } else
        {
            answerOneText.text = answerTwo.ToString();
            answerTwoText.text = answerOne.ToString();
            rightButtonIndex = 1;
        }
    }

    public void ButtonAnswer(int answer)
    {
        if (rightButtonIndex == answer)
        {
            myFX.clip = rightFX;
            myFX.Play();
            levelProgress++;
        }
        else
        {
            myFX.clip = wrongFX;
            myFX.Play();
        }
        DisplayMathProblem();
    }

}
