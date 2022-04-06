using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float Xaxis;
    public float Yaxis;
    public float RotationSensitivity = 1.5f;
    [SerializeField] private FixedJoystick joystick;
    void Update()
    {
        Yaxis += joystick.Horizontal;
        Xaxis -= joystick.Vertical;
        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;
    }
}
