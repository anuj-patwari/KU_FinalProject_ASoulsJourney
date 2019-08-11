using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    CharacterController2D controller;
    JumpDisable jd;
    GameManager gm;

    [SerializeField] float jumpCount = 0f;
    [SerializeField] GameObject cross;

    [SerializeField] Sprite transparent;
    [SerializeField] Sprite normal;

    public bool placed;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<CharacterController2D>();
        jd = FindObjectOfType<JumpDisable>();
        gm = FindObjectOfType<GameManager>();
        Player.PlayerDied.AddListener(OnPlayerDied);
        GameManager.PrepPhaseStarted.AddListener(PreparationHasStarted);
        GameManager.PrepPhaseEnded.AddListener(PreparationHasEnded);

        if (placed == true)
        {
            cross.SetActive(true);
        }

        else if (placed == false)
        {
            cross.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && controller.m_Grounded && controller.m_JumpForce > 0 && gm.prepPhase == false)
        {
            if (jumpCount < 3f)
            {
                jumpCount++;
            }

            if (jumpCount == 3f)
            {
                jumpCount = 0f;
                gameObject.GetComponent<SpriteRenderer>().sprite = normal;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }

            if (jumpCount == 2f)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = transparent;
            }

            if (jumpCount == 1f)
            {
                StartCoroutine(DisablePlatform(0.1f));
            }
        }
    }

    IEnumerator DisablePlatform(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnPlayerDied()
    {
        jumpCount = 0f;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void PreparationHasEnded()
    {
        jumpCount = 0f;
        cross.SetActive(false);
    }

    void PreparationHasStarted()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (placed == true)
        {
            cross.SetActive(true);
        }
    }
}
