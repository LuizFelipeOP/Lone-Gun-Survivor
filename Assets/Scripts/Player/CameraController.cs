using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = .3f;
    //public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
 
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;

        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
