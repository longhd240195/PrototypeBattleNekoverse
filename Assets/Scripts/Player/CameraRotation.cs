using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float Speed = 5.0f;
    //public Transform camTarget;
    public Transform lookTarget;
    public Vector3 dist;
    void LateUpdate()
    {
        Vector3 dPos = lookTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, Speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}
