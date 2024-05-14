using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;


public class NumberGenerator : MonoBehaviour
{
    public TextMeshProUGUI signText;

    public Slot slot1;
    public Slot slot2;

    public GameObject[] numbers;
    private Vector3[] numberPos;

    private int targetNumber;

    private int slot1Number = 999;
    private int slot2Number = 999;

    public int levelProgress = 0;
    public GameManager gameManager;

    public AudioSource myFX;
    public AudioClip awesomeFX;

    private void Start()
    {
        GenerateTargetNumber();
        numberPos = new Vector3[numbers.Length];
        
        for (int i = 0; i < numbers.Length; i++)
        {
            numberPos[i] = numbers[i].transform.position;
        }
    }

    private void Update()
    {
        if (levelProgress == 4)
        {
            Debug.Log("Уровень пройден");
            levelProgress = 0;
            gameManager.Winning();
        }
    }



    private void GenerateTargetNumber()
    {
        targetNumber = Random.Range(10, 100);
        while (targetNumber % 11 == 0)
        {
            targetNumber = Random.Range(10, 100);
        }
        signText.text = targetNumber.ToString();
        slot1.currentNumberInSlot = "99";
        slot2.currentNumberInSlot = "99";
    }

    public void CheckTargetNumber()
    {
        int.TryParse(slot1.currentNumberInSlot, out slot1Number);
        int.TryParse(slot2.currentNumberInSlot, out slot2Number);
        int combinedNumber = slot1Number * 10 + slot2Number;

        if (combinedNumber == targetNumber)
        {
            levelProgress++;
            if (levelProgress != 4)
            {
                GenerateTargetNumber();
                myFX.PlayOneShot(awesomeFX);
            }
            for (int i = 0;i < numbers.Length;i++)
            {
                numbers[i].transform.position = numberPos[i];
            }
        }
    }
}