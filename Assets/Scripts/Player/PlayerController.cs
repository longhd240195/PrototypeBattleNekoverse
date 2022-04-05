using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity = 0.1f;
    private NavMeshAgent navMeshAgent;
    public float moveForce = 5f;
    public float speed = 5f;
    public float rotationSpeed = 100.0f;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(moveJoystick.Horizontal,0f, moveJoystick.Vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            navMeshAgent.Move(dir.normalized * speed * Time.deltaTime);
        }

    }

}
