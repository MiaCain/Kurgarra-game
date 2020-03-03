using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool WillVanish = true;
    float timer = 0.0f;
    public PickupCounter SKeys;
    private bool collected = false;

    private void Start()
    {
        SKeys = GameObject.Find("Player").GetComponent<PickupCounter>();
    }

    // check to see if player has entered. if yes, call relevant script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collected == false)
        {
            if (SKeys.currentKeys < SKeys.maxKeys)
            {
                SKeys.currentKeys = SKeys.currentKeys + 1;
                Destroy(this.gameObject);
                collected = true;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
