using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity = 0.1f;
    private NavMeshAgent navMeshAgent;
    public float speed = 2f;
    public Transform effect;
    public Transform parentEffect;
    public Animator animator;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        Vector3 dir = new Vector3(moveJoystick.Horizontal, 0f, moveJoystick.Vertical).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            navMeshAgent.Move(dir.normalized * speed * Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(MakeObject());
        }


    }
    IEnumerator MakeObject()
    {
        animator.Play("pre-skill");
        Transform vfx = Instantiate(effect, parentEffect);
        yield return new WaitForSeconds(10f);
        animator.Play("Idle");
        Destroy(vfx.gameObject);
    }
}
