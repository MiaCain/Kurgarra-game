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
        if (Percentage > 0.0f)
        {

            if (Percentage > 40.0f)
            {

                if (Percentage > 55.0f)
                {
                    if (Percentage > 80.0f)
                    {
                        if (Percentage > 96.0f)
                        {
                            if (Percentage > 99.5f)
                            {
                                //huge coin
                                return 4;
                            }
                            else
                            {
                                //large coin
                                return 3;
                            }
                        }
                        else
                        {
                            //med coin
                            return 2;
                        }
                    }
                    else
                    {
                        //small coin
                        return 1;
                    }
                }
                else
                {
                    //nothing
                    return 6;
                }
            }
            else
            {
                //heart
                return 0;
            }
        }

        else
        {
            return 0;
        }
    }

}
