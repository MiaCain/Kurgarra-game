using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{


    public Text AmountOwned;

    public int currentKeys;
    public int maxKeys = 10;

    private void Update()
    {
        AmountOwned.text = ("x" + currentKeys.ToString());

        if (currentKeys > maxKeys)
        {
            currentKeys = 10;
        }
    }



}
