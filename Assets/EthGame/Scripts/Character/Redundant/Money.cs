using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{


    public Text AmountOwned;

    public int currentMoney;
    public int maxMoney = 256;

    private void Update()
    {
        AmountOwned.text = ("x" + currentMoney.ToString());

        if (currentMoney > maxMoney)
        {
            currentMoney = 256;
        }
    }



}
