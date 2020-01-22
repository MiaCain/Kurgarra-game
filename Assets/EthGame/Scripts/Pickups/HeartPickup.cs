using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{

    public bool WillVanish = true;
    public Health Health;
    float timer = 0.0f;

    float spriteBlinkingTimer = 0.0f;
    float spriteBlinkingMiniDuration = 0.1f;
    float spriteBlinkingTotalTimer = 0.0f;
    float spriteBlinkingTotalDuration = 5.0f;

    private void Start()
    {
        Health = GameObject.Find("Player").GetComponent<Health>();
    }

    // check to see if player has entered. if yes, call relevant script
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Health.currentHealth < Health.maxHealth)
            {
                Health.currentHealth = Health.currentHealth + 1;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }

    // update a timer, if it gets to a late enough point, call blink, then destroy
    void Update()
    {
        if (WillVanish = true)
        {
            timer += Time.deltaTime;
            spriteBlinkingMiniDuration = timer / 35;

            if (timer > 3)
            {
                SpriteBlinkingEffect();
            }

            if (timer > 5)
            {
                Destroy(this.gameObject);
            }
        }

    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
}
