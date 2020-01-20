using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator Anim;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public GameObject SwordN;
    public GameObject SwordS;
    public GameObject SwordE;
    public GameObject SwordW;
    int MovementDir;

    private Vector2 knockbackDir;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Input
        stopHitting();

        if (Input.GetButton("up")) {
            Anim.SetInteger("MovementDirection", 2);
            Anim.SetBool("isMoving", true);
            MovementDir = 2;
            movement.y = 1;
            movement.x = 0;

        }
        else if (Input.GetButton("down"))
        {
            Anim.SetInteger("MovementDirection", 1);
            Anim.SetBool("isMoving", true);
            MovementDir = 1;
            movement.y = -1;
            movement.x = 0;
        }
        else if (Input.GetButton("left"))
        {
            Anim.SetInteger("MovementDirection", 3);
            Anim.SetBool("isMoving", true);
            MovementDir = 3;
            movement.y = 0;
            movement.x = -1;
        }
        else if (Input.GetButton("right"))
        {
            Anim.SetInteger("MovementDirection", 4);
            Anim.SetBool("isMoving", true);
            MovementDir = 4;
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
            //Anim.SetBool("isStabbing", true);
            if (MovementDir == 1)
            {
                SwordS.SetActive(true);
            }

            if (MovementDir == 2)
            {
                SwordN.SetActive(true);
            }

            if (MovementDir == 3)
            {
                SwordW.SetActive(true);
            }

            if (MovementDir == 4)
            {
                SwordE.SetActive(true);
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
        SwordN.SetActive(false);
        SwordS.SetActive(false);
        SwordE.SetActive(false);
        SwordW.SetActive(false);
        //this.Anim.SetBool("isStabbing", false);
    }

}
