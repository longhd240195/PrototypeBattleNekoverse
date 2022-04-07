using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public float angleX = 0;
    public float angleY = 0;
    public float angleZ = 0;

    private void OnEnable()
    {
        transform.eulerAngles = new Vector3(angleX, angleY, angleZ);
    }
}
