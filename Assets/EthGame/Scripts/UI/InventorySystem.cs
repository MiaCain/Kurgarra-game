using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public InventoryMove InvMove;
    public UseItem ItemScript;
    public ItemsOwned ItemsOwned;
    public GameObject[] ItemList;
    public GameObject Selector;
    public int CurrentItem;
    public bool Row;
    public bool Edge;


    void Awake()
    {
        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemsOwned.hasItem[i])
            {
                ItemList[i].gameObject.GetComponent<RawImage>().enabled = true;
            }

            else
            {
                ItemList[i].gameObject.GetComponent<RawImage>().enabled = false;
            }
        }
    }

    void Update()
    {
        ItemScript.ItemType = CurrentItem + 1;

        if (InvMove.isOpen && InvMove.isMoving == false)
        {
            if (Input.GetButtonDown("up"))
            {
                MoveUp();
            }

            if (Input.GetButtonDown("down"))
            {
                MoveDown();
            }

            if (Input.GetButtonDown("left"))
            {
                MoveLeft();
            }

            if (Input.GetButtonDown("right"))
            {
                MoveRight();
            }
        }

        if (CurrentItem <= 0)
        {
            CurrentItem = 0;
            this.gameObject.transform.position = ItemList[0].gameObject.transform.position;
        }

        if (CurrentItem >= 15)
        {
            CurrentItem = 15;
            this.gameObject.transform.position = ItemList[15].gameObject.transform.position;
        }

    }

    public void updateItemList()
    {
        for (int i = 0; i < ItemList.Length; i++)
        {
            if (ItemsOwned.hasItem[i])
            {
                ItemList[i].gameObject.GetComponent<RawImage>().enabled = true;
            }

            else
            {
                ItemList[i].gameObject.GetComponent<RawImage>().enabled = false;
            }
        }
    }

    public void MoveUp()
    {
        this.gameObject.transform.position = ItemList[CurrentItem - 8].gameObject.transform.position;
        CurrentItem = CurrentItem - 8;
    }

    public void MoveDown()
    {
        this.gameObject.transform.position = ItemList[CurrentItem + 8].gameObject.transform.position;
        CurrentItem = CurrentItem + 8;
    }

    public void MoveLeft()
    {
        this.gameObject.transform.position = ItemList[CurrentItem -1].gameObject.transform.position;
        CurrentItem = CurrentItem - 1;
    }

    public void MoveRight()
    {
        this.gameObject.transform.position = ItemList[CurrentItem + 1].gameObject.transform.position;
        CurrentItem = CurrentItem + 1;
    }
}
