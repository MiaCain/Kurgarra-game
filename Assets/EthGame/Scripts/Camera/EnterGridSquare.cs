using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGridSquare : MonoBehaviour
{
    public GameObject MainCam;
    private CameraLERPConstant CameraLERPConstant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CameraLERPConstant = MainCam.GetComponent<CameraLERPConstant>();
            CameraLERPConstant.myTargetPosition = this.gameObject;
        }
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CameraLERPConstant = MainCam.GetComponent<CameraLERPConstant>();
            CameraLERPConstant.myTargetPosition = this.gameObject;
        }

    }
}
