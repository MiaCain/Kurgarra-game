using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerOldSword : MonoBehaviour
{
    Animator Anim;

    bool CanMove = true;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;


    public GameObject SwordN;
    public GameObject SwordS;
    public GameObject SwordE;
    public GameObject SwordW;

    private Vector2 knockbackDir;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Input
        if(CanMove == true) { 
        if (Input.GetButton("up")) {
            Anim.SetInteger("MovementDirection", 2);
            Anim.SetBool("isMoving", true);
            movement.y = 1;
            movement.x = 0;

        }
        else if (Input.GetButton("down"))
        {
            Anim.SetInteger("MovementDirection", 1);
            Anim.SetBool("isMoving", true);
            movement.y = -1;
            movement.x = 0;
        }
        else if (Input.GetButton("left"))
        {
            Anim.SetInteger("MovementDirection", 3);
            Anim.SetBool("isMoving", true);
            movement.y = 0;
            movement.x = -1;
        }
        else if (Input.GetButton("right"))
        {
            Anim.SetInteger("MovementDirection", 4);
            Anim.SetBool("isMoving", true);
            movement.y = 0;
            movement.x = 1;
        }
        else{
            Anim.SetBool("isMoving", false);
            movement.y = 0;
            movement.x = 0;
        }

            if (Input.GetButton("b"))
            {
                Anim.SetBool("isStabbing", true);
                CanMove = false;
                movement = movement / new Vector2(5f, 5f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyCom")
        {
            //Knockback
            knockbackDir = this.transform.position - collision.transform.position;
            this.rb.AddForce(knockbackDir.normalized * 1500f);
        }

    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    public void HitEnemyNorth()
    {
        SwordN.SetActive(true);
    }

    public void HitEnemySouth()
    {
        SwordS.SetActive(true);
    }

    public void HitEnemyEast()
    {
        SwordE.SetActive(true);
    }

    public void HitEnemyWest()
    {
        SwordW.SetActive(true);
    }

    public void stopHitting()
    {
        Anim.SetBool("isStabbing", false);
        SwordN.SetActive(false);
        SwordS.SetActive(false);
        SwordE.SetActive(false);
        SwordW.SetActive(false);
        CanMove = true;

    }

}
