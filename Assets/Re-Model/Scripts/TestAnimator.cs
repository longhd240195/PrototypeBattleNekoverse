using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("prepare-attack");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("attack");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("end-attack");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("Idle");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("run_body");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("pre-skill");
        }
    }
}
