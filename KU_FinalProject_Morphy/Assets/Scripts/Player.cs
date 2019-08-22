using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class Player : MonoBehaviour
{

    public CharacterController2D controller;
    public static UnityEvent PlayerDied = new UnityEvent();
    GameManager gm;
    GlobalAudioManager gam;

    public Animator animator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<CharacterController2D>();
        gm = FindObjectOfType<GameManager>();
        gam = FindObjectOfType<GlobalAudioManager>();
        animator.SetFloat("Speed", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (gm.prepPhase == false && gm.paused == false)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        if (Input.GetButtonDown("Jump"))
        {

            jump = true;
            

            if (controller.m_JumpForce != 0)
            {
                if(gm.prepPhase == false && gm.paused == false)
                {
                    animator.SetBool("IsJumping", true);
                    controller.timer = 3;
                }
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void Die()
    {
        gam.deaths++;
        gam.SaveGame();
        PlayerDied.Invoke();
    }
}