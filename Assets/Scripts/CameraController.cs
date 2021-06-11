using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] public EndOfPathInstruction endOfPathInstruction;
    [SerializeField] private float distanceTravelled = 0;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Vector3 camOffset;

    // Update is called once per frame
    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction) + camOffset;
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }

        if(OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
            speed = 10.0f;
        else if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))
            speed = 0.0f;
        else
            speed = 1.0f;
    }
}
