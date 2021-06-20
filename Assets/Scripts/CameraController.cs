using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    public Vector3 targetOffset = new Vector3(-10, -10, 0);
    public float smoothSpeed = 0.125f;

    void LateUpdate() {
        Vector3 destinationPoint = target.position - targetOffset;
        transform.position = Vector3.Lerp(transform.position, destinationPoint, smoothSpeed);
    }
}
