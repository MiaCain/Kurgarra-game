using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLERPConstant : MonoBehaviour
{
    public float speed;
    public GameObject myTargetPosition;
    public BoxCollider2D freezeMainScene;
    private bool isMoving;

    void Start()
    {

    }
    void Update()
    {
        if(transform.position == myTargetPosition.transform.position)
        {
            isMoving = false;
            freezeMainScene.enabled = false;
        }

        else
        {
            isMoving = true;
        }

        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, myTargetPosition.transform.position, step);
        }
    }
}
