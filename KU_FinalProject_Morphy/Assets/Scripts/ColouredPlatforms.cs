using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColouredPlatforms : MonoBehaviour
{
    Player player;
    GameManager gm;

    [Tooltip("1 for White, 2 for Purple, 3 for Red")]
    public float platformColor;



    [SerializeField] GameObject cross;
    public bool placed;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();

        Player.PlayerDied.AddListener(OnPlayerDied);
        GameManager.PrepPhaseStarted.AddListener(PreparationHasStarted);
        GameManager.PrepPhaseEnded.AddListener(PreparationHasEnded);

        if (platformColor == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c1;
            cross.GetComponent<SpriteRenderer>().color = player.c1;
        }

        else if (platformColor == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c2;
            cross.GetComponent<SpriteRenderer>().color = player.c2;
        }
        else if (platformColor == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = player.c3;
            cross.GetComponent<SpriteRenderer>().color = player.c3;
        }

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
        if (player.playerColor == platformColor)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnPlayerDied()
    {
        
    }

    void PreparationHasEnded()
    {
        cross.SetActive(false);
    }

    void PreparationHasStarted()
    {
        if (placed == true)
        {
            cross.SetActive(true);
        }
    }
}