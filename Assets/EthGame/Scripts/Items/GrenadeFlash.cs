using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeFlash : MonoBehaviour
{

    public float Countdown = 6f;

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;

    public Sprite SprNorm;
    public Sprite SprRed;
    public SpriteRenderer Renderer;
    public bool isFrozen = false;

    private void Start()
    {
        Renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFrozen == false)
        {
            Countdown -= Time.fixedDeltaTime;

            spriteBlinkingMiniDuration = -Countdown / 15 * -1;

            if (Countdown <= 3)
            {
                SpriteBlinkingEffect();
            }

            if (Countdown <= 0)
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
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            Renderer.sprite = SprNorm;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (Renderer.sprite = SprNorm)
            {
                Renderer.sprite = SprRed;  //make changes
            }
            else
            {
                Renderer.sprite = SprNorm;   //make changes
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isFrozen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isFrozen = false;
        }
    }
}
