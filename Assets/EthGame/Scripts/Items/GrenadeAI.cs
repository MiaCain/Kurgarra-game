using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeAI : MonoBehaviour
{
    Animator Anim;
    public GameObject Player;

    Vector3 pos;
    private Vector2 movement;
    private Vector2 StoreMovement;
    private Vector2 knockbackDir;
    public float KnockbackPower = 1500f;
    Rigidbody2D rb;

    private float timeLeft;

    public GrenadeFlash GrenadeFlash;
    public GrenadeExplode GrenadeExplode;

    public bool isFrozen = false;


    //Find Player, find animator, find RB, find LootScript
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        GrenadeExplode = this.gameObject.GetComponent<GrenadeExplode>();
        GrenadeFlash = this.gameObject.GetComponent<GrenadeFlash>();
    }

    // Update is called once per frame
    void Update()
    {
        //kill enemy, call flash script
        if (GrenadeFlash.Countdown <= 0.1f)
        {
            GrenadeExplode.Explode();
        }

        if (isFrozen)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
            knockbackDir = this.transform.position - Player.transform.position;
            this.rb.AddForce(knockbackDir.normalized * KnockbackPower);
        }
        if (collision.gameObject.tag == "MainCamera")
        {
            StoreMovement = movement;
            isFrozen = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            isFrozen = false;
            movement = StoreMovement;
        }
    }
}

