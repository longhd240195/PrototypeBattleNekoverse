using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick lookJoystick;
    private NavMeshAgent navMeshAgent;
    public float moveForce = 5f;
    public float speed = 5f;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {

    }

}
