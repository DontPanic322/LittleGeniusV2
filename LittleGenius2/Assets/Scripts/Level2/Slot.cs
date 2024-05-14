using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour

{
    public DraggingItems itemInSlot;
    public string currentNumberInSlot = "99";

    [SerializeField]
    private NumberGenerator numGen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentNumberInSlot = item.itemName;
            itemInSlot = item;
            numGen.CheckTargetNumber();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DraggingItems item = collision.GetComponent<DraggingItems>();
        if (collision.tag == "Item")
        {
            currentNumberInSlot = "";
            itemInSlot = null;
            numGen.CheckTargetNumber();
        }
    }
}