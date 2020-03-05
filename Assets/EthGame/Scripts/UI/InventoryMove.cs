using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMove : MonoBehaviour
{
    public bool isOpen = false;
    private bool isMoving = false;
    public GameObject InvMover;
    public GameObject TargetOpen;
    public GameObject TargetClosed;
    public BoxCollider2D freezeMainScene;

    public float speed = 300;

    // Update is called once per frame
    void Update()
    {
        if (InvMover.transform.position == TargetClosed.transform.position || InvMover.transform.position == TargetOpen.transform.position)
        {
            isMoving = false;
        }

        if (isOpen)
        {
            
            float step = speed * Time.deltaTime;
            InvMover.transform.position = Vector3.MoveTowards(InvMover.transform.position, TargetOpen.transform.position, step);
            freezeMainScene.enabled = true;

            if (Input.GetButton("start") && isMoving == false)
            {
                isMoving = true;
                isOpen = false;
            }
        }

        if (isOpen == false)
        {
            
            float step = speed * Time.deltaTime;
            InvMover.transform.position = Vector3.MoveTowards(InvMover.transform.position, TargetClosed.transform.position, step);
            freezeMainScene.enabled = false;

            if (Input.GetButton("start") && isMoving == false)
            {
                isMoving = true;
                isOpen = true;
            }
        }
    }
}
