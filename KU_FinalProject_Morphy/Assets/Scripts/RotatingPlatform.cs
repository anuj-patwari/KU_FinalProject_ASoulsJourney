using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] GameObject player;
    CharacterController2D controller;
    JumpDisable jd;
    public Animator anim;
    public bool placed = false;
    public GameObject crossButton;
    public float startingRotation;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startingRotation = gameObject.GetComponent<Transform>().rotation.z;
        gm = FindObjectOfType<GameManager>();
        GameManager.PrepPhaseEnded.AddListener(PrepPhaseOff);
        GameManager.PrepPhaseStarted.AddListener(PrepPhaseOn);
        controller = FindObjectOfType<CharacterController2D>();
        jd = FindObjectOfType<JumpDisable>();
        anim = GetComponent<Animator>();
        Player.PlayerDied.AddListener(OnPlayerDied);
        if (placed == true && gm.prepPhase == true)
        {
            crossButton.SetActive(true);
        }
        else if (placed == false)
        {
            crossButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && controller.m_Grounded && player.GetComponent<CharacterController2D>().m_JumpForce > 0 && gm.prepPhase == false)
        {
            if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
            {
                anim.enabled = true;
                anim.Play("RotateTo180");
            }

            if (transform.rotation.eulerAngles.z == Mathf.Abs(180f))
            {
                anim.enabled = true;
                anim.Play("RotatingPlatform2");
            }
        }
    }

    void OnPlayerDied()
    {
        if (transform.rotation.eulerAngles.z == Mathf.Abs(180f) && startingRotation != -1)
        {
            anim.enabled = true;
            anim.Play("RotatingPlatform2");
        }
        
        else if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
        {
            if (startingRotation == -1)
            {
                anim.enabled = true;
                anim.Play("RotateTo180");
            }
        }
    }

    void PrepPhaseOff()
    {
        crossButton.SetActive(false);
    }

    void PrepPhaseOn()
    {
        if (placed == true)
        {
            crossButton.SetActive(true);
        }

        if(transform.rotation.eulerAngles.z == Mathf.Abs(180f) && startingRotation != -1)
        {
            anim.enabled = true;
            anim.Play("RotatingPlatform2");
        }

        else if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
        {
            if (startingRotation == -1)
            {
                anim.enabled = true;
                anim.Play("RotateTo180");
            }
        }
    }
}