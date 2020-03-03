using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanaFlash : MonoBehaviour
{
    public PickupCounter Health;

    public int delay = 10;
    public SpriteRenderer mySpriteRenderer;
    int counter;
    bool toggle = false;

    private void Start()
    {
        Health = GameObject.Find("Player").GetComponent<PickupCounter>();
    }

    void FixedUpdate()    // you can you FixedUpdate for fixed flash rate
    {
        if(Health.CanBeDamaged == false)
        Flash(mySpriteRenderer);

        else
        {
            mySpriteRenderer.enabled = true;
        }
    }

    void Flash(SpriteRenderer spriteRen)
    {


        if (counter >= delay)
        {
            counter = 0;

            toggle = !toggle;
            if (toggle)
            {
                spriteRen.enabled = true;
            }
            else
            {
                spriteRen.enabled = false;
            }

        }
        else
        {
            counter++;
        }
    }


}
