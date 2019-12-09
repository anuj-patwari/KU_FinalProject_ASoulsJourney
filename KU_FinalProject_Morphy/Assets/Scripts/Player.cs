﻿using System.Collections;
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

    public float playerColor;
    public Color c1, c2, c3;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<CharacterController2D>();
        gm = FindObjectOfType<GameManager>();
        gam = FindObjectOfType<GlobalAudioManager>();
        animator.SetFloat("Speed", 0f);

        if (gm.levelNumber < 10)
        {
            playerColor = 1;
        }
        else if (gm.levelNumber > 10 && gm.levelNumber < 19)
        {
            gameObject.GetComponent<SpriteRenderer>().color = c2;
            playerColor = 2;
        }
        else if (gm.levelNumber > 19)
        {
            playerColor = 3;
            gameObject.GetComponent<SpriteRenderer>().color = c3;
        }

        if (gm.levelNumber == 10)
        {
            gameObject.GetComponent<SpriteRenderer>().color = c1;
            gameObject.GetComponent<CharacterController2D>().enabled = false;
            playerColor = 2;
            StartCoroutine(Level10Animation(1.6f)); 
        }

        if (gm.levelNumber == 19)
        {
            gameObject.GetComponent<SpriteRenderer>().color = c2;
            gameObject.GetComponent<CharacterController2D>().enabled = false;
            playerColor = 3;
            StartCoroutine(Level19Animation(1.6f));
        }
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

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (gm.levelNumber > 9 && gm.levelNumber <= 18)
            {
                if (playerColor == 1)
                {
                    playerColor = 2;
                    gameObject.GetComponent<SpriteRenderer>().color = c2;
                    print("its Purple now");
                }
                else if (playerColor == 2)
                {
                    playerColor = 1;
                    gameObject.GetComponent<SpriteRenderer>().color = c1;
                    print("its White now");
                }
            }

            else if (gm.levelNumber > 18)
            {
                if (playerColor == 1)
                {
                    playerColor = 2;
                    gameObject.GetComponent<SpriteRenderer>().color = c2;
                    print("its Purple now");
                }
                else if (playerColor == 2)
                {
                    playerColor = 3;
                    gameObject.GetComponent<SpriteRenderer>().color = c3;
                    print("its Red now");
                }
                else if (playerColor == 3)
                {
                    playerColor = 1;
                    gameObject.GetComponent<SpriteRenderer>().color = c1;
                    print("its White now");
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

    IEnumerator Level10Animation(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<CharacterController2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = c2;
    }

    IEnumerator Level19Animation(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<CharacterController2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = c3;
    }
}