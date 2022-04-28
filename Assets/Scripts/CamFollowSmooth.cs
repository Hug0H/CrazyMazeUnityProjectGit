using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowSmooth : MonoBehaviour
{

    public Transform target;
    private Vector3 offsetCamera ;

    float smooth=0.125f;

    void FixedUpdate()
    {
        Vector3 cameraPosition = target.position + offsetCamera;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smooth);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }

    public void setTarget(Transform newtarget)
    {
        target = newtarget;
    }
}