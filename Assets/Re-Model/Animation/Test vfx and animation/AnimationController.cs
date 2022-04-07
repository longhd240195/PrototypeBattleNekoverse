using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public Transform[] effectVFX;
    //public Transform[] objectToDestroy = new Transform[5];
    public Transform objectToDestroy;

    Transform go;

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("FastAttack");   
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("ChargeAttack");    
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("2HandAttack");
            SpawnVFX(0, 0.1f, new Vector3(0, 180, 0), -0.2f, 0.5f, 1f);
        }
    }

    public void SpawnFastAttackVFX()
    {
        SpawnVFX(1, 0.05f, new Vector3(0, 180, 0), 0, 0.3f, 1f);
    }

    public void SpawChargeAttackVFX()
    {
        SpawnVFX(2, 0.1f, new Vector3(0, 0, 0), 0, 0, 1);
    }


    public void SpawnVFX(int index, float scale, Vector3 eulerAngles, float x, float y, float z)
    {
        if(objectToDestroy != null)
        {
            Destroy(objectToDestroy.gameObject);
        }

        go = Instantiate(effectVFX[index], transform.position, Quaternion.identity);
        go.transform.localScale = Vector3.one * scale;
        go.transform.parent = transform;
        go.localPosition = new Vector3(go.localPosition.x + x, go.localPosition.y + y, go.localPosition.z + z);
        go.eulerAngles = eulerAngles;
        objectToDestroy = go;
    }

    public void SetAnimatorSpeed(float spd)
    {
        animator.speed = spd;
    }

    public void ResetSpeed()
    {
        animator.speed = 1;
    }
}
