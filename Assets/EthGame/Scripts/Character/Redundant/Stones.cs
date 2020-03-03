using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stones : MonoBehaviour
{
    public Text AmountOwned;

    public int currentStones;
    public int maxStones = 16;

    private void Update()
    {
        AmountOwned.text = ("x" + currentStones.ToString());

        if (currentStones > maxStones)
        {
            currentStones = maxStones;
        }
    }

}
