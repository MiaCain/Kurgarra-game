using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.y == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (rb.velocity.x == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
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

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
