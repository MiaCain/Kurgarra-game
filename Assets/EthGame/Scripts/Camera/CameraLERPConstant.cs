using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLERPConstant : MonoBehaviour
{
    public float speed;
    public GameObject myTargetPosition;
    public Transform startMarker;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;


        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, myTargetPosition.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float moveTime = Time.deltaTime * speed;
        
        transform.position = Vector3.Lerp(transform.position, myTargetPosition.transform.position, moveTime);
    }
}
