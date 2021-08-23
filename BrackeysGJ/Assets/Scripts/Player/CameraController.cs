using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float height;
    [SerializeField] float distance;

    private void FixedUpdate()
    {
        transform.position = target.transform.TransformPoint(0, height, distance);
    }
}