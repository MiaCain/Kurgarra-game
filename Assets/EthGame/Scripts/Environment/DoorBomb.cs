using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.tag == "ExplosionCloud")
        {
            Destroy(this.gameObject, 0.1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D");
        if (collision.tag == "ExplosionCloud")
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
}
