using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropLootRandom : MonoBehaviour
{
    public GameObject[] Loot;
    public Mathf LootTable;
    public int LootNumber;
    public bool CanDrop = true;



    public void dropLoot()
    {
        if (CanDrop == true)
        {
            LootNumber = CalculateLoot();
            Instantiate(Loot[LootNumber], transform.position, Quaternion.identity);
            CanDrop = false;
        }
    }

    int CalculateLoot()
    {
        float Percentage = Random.Range(0.0f, 100.0f);

        //use this to calculate likelyhood of different objects being spawned. Heart should be 45%, small coin should be 25%.
        if (Percentage > 0.0f || Percentage < 45.0f)
        {
            //heart
            return 0;
        }

        if (Percentage > 45.0f || Percentage < 70.0f)
        {
            //small coin
            return 1;
        }

        if (Percentage > 70.0f || Percentage < 85.0f)
        {
            //med coin
            return 2;
        }

        if (Percentage > 85.0f || Percentage < 95.0f)
        {
            //large coin
            return 3;
        }

        if (Percentage > 95.0f || Percentage < 99.5f)
        {
            //huge coin
            return 4;
        }

        if (Percentage > 99.5f || Percentage < 100.0f)
        {
            //mega coin
            return 5;
        }

        else
        {
            return 0;
        }
    }

}
