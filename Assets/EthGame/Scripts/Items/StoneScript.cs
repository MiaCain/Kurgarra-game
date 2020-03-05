using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    private bool isFrozen = false;
    private Vector2 origDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y == 0 && isFrozen == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (rb.velocity.x == 0 && isFrozen == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (isFrozen)
        {
            rb.velocity = new Vector2(0,0);
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0 || 1.0 < pos.x || pos.y < 0.0 || 1.0 < pos.y)
        {
            DestroyThis();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("hitObject");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        origDirection = rb.velocity;
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
            rb.velocity = origDirection;
        }
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
