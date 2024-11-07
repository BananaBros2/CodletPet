using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void OpenGate()
    {
        animator.SetTrigger("Open");
    }
}
