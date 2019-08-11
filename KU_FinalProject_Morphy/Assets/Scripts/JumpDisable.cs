using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpDisable : MonoBehaviour
{
    CharacterController2D cc2d;
    private float positiveJumpForce;
    private float negativeJumpForce;
    public bool jumpEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        cc2d = FindObjectOfType<CharacterController2D>();
        positiveJumpForce = cc2d.m_JumpForce;
        negativeJumpForce = cc2d.n_JumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cc2d.m_JumpForce = 0f;
        cc2d.n_JumpForce = 0f;
        jumpEnabled = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        cc2d.m_JumpForce = positiveJumpForce;
        cc2d.n_JumpForce = negativeJumpForce;
        jumpEnabled = true;
    }
}
