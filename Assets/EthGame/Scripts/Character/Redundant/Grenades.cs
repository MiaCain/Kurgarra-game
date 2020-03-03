using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grenades : MonoBehaviour
{

    public Text AmountOwned;

    public int currentGrenades;
    public int maxGrenades = 8;

    private void Update()
    {
        AmountOwned.text = ("x" + currentGrenades.ToString());

        if (currentGrenades > maxGrenades)
        {
            currentGrenades = maxGrenades;
        }
    }

}
