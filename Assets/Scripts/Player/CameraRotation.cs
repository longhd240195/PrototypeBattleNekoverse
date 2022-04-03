using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float Xaxis;
    public float Yaxis;
    public float RotationSensitivity = 1.5f;
    void Update()
    {
        Yaxis += Input.GetAxis("Mouse X");
        Xaxis -= Input.GetAxis("Mouse Y");
        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;
    }
}
