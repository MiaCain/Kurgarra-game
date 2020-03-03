using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{

    //get the current amount of keys
    public PickupCounter Keys;




    //get the collision, delete door, remove key

    void Start()
    {
        Keys = GameObject.Find("Player").GetComponent<PickupCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Keys.currentKeys < Keys.maxKeys && Keys.currentKeys >= 1)
            {
                Keys.currentKeys = Keys.currentKeys - 1;
                Destroy(this.gameObject, 0.5f);
            }
        }
    }
}
