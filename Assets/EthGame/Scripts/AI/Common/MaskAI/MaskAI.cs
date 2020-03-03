using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAI : MonoBehaviour
{
    public bool CanMove;
    public Rigidbody2D MaskRigid;
    public float MMag;
    private Vector2 MDir;

    private Vector2 deadX;
    private Vector2 deadY;
    private Vector2 pos;
    

    // Start is called before the first frame update
    void Start()
    {
        MDir = new Vector2(MMag, MMag);
        MaskRigid.velocity = MDir;
        deadY = new Vector2(MaskRigid.velocity.x, 0f);
        deadX = new Vector2(0f, MaskRigid.velocity.y);
    }

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0 || 1.0 < pos.x || pos.y < 0.0 || 1.0 < pos.y)
        {
            CanMove = false;
            MaskRigid.velocity = new Vector2(0f, 0f);
        }

        else
        {
            CanMove = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanMove == true)
        {
            if (MaskRigid.velocity.magnitude < MMag)
            {
                MaskRigid.velocity = MDir;
            }
        }
        
    }
}
