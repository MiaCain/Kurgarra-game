using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardAI : MonoBehaviour
{
    Animator Anim;
    public GameObject Player;

    public float speed = 2;
    public int health = 3;
    public float accTime = 3;


    private bool CanMove = true;
    private Vector2 movement;
    private Vector2 knockbackDir;
    public float KnockbackPower = 1500f;
    Rigidbody2D rb;

    private float timeLeft;

    private SpriteRenderer LizSprite;
    public EnemyFlash EnemyFlash;



    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove == true) { 
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            if (movement.x >= 0){
                Anim.SetBool("movingLeft", false);
            }
            else
            {
                Anim.SetBool("movingLeft", true);
            }

            timeLeft += accTime;
        }
        }



        if (health <= 0)
        {
            CanMove = false;
            this.tag = "EnemyDying";
            movement = new Vector2 (0f,0f);
            this.EnemyFlash.SpriteDeathEffect();
            Destroy(this.gameObject, EnemyFlash.spriteBlinkingTotalDuration *2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
            knockbackDir = this.transform.position - Player.transform.position;
            this.rb.AddForce(knockbackDir.normalized * KnockbackPower);
            health = health - 1;
            this.EnemyFlash.InitOnHit();
        }

    }

     private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }

    public void SpriteFlash()
    {
        EnemyFlash.InitOnHit();
    }
}
