using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float moveXWASD = Input.GetAxis("Horizontal_WASD");
        float moveXarr = Input.GetAxis("Horizontal_Arrows");
        if (moveXWASD == 0 && moveXarr == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
    }
}
