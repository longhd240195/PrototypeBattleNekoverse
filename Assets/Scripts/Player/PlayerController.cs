using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Joystick moveJoystick;
    public Transform[] m_effects;
    public int inputLocation;
    GameObject gm;
    public GameObject scaleform;
    public GameObject[] m_destroyObjects = new GameObject[30];
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity = 0.1f;
    private NavMeshAgent navMeshAgent;
    public float speed = 2f;
    public Camera camera;
    public static float m_gaph_scenesizefactor = 1;
    private void Awake()
    {
        inputLocation = 0;
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



        //if (Input.GetMouseButtonDown(0))
        //{
        //    MakeObject();
        //}


    }
    //void MakeObject()
    //{
    //    int index = Random.Range(0, 10);
    //    DestroyGameObject();
    //    gm = Instantiate(m_effects[index],
    //        m_effects[index].transform.position,
    //        m_effects[index].transform.rotation).gameObject; 
    //    scaleform.transform.position = gm.transform.position;
    //    gm.transform.parent = scaleform.transform;
    //    gm.transform.localScale = new Vector3(1, 1, 1);
    //    float submit_scalefactor = m_gaph_scenesizefactor;
    //    if (index < 70)
    //        submit_scalefactor *= 0.5f;
    //    gm.transform.localScale = new Vector3(submit_scalefactor, submit_scalefactor, submit_scalefactor);
    //    m_destroyObjects[inputLocation] = gm;
    //    inputLocation++;
    //}

    //void DestroyGameObject()
    //{
    //    for (int i = 0; i < inputLocation; i++)
    //    {
    //        Destroy(m_destroyObjects[i]);
    //    }
    //    inputLocation = 0;
    //}
}
