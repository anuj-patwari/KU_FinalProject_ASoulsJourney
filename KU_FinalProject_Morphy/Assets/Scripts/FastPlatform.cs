using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlatform : MonoBehaviour
{

    public bool hasLeftCollision = false;
    Player player;
    GameManager gm;

    IEnumerator stopBackToFalse;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();

        stopBackToFalse = BackToFalse(3);

        Player.PlayerDied.AddListener(OnPlayerDied);
        GameManager.PrepPhaseStarted.AddListener(PreparationHasStarted);
        GameManager.PrepPhaseEnded.AddListener(PreparationHasEnded);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasLeftFPCollision == true)
        {
            if (player.runSpeed > 20)
            {
                player.runSpeed -= Time.deltaTime * 10f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.hasLeftFPCollision = false;
        StopCoroutine(stopBackToFalse);
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<Player>().runSpeed = 80;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            player.hasLeftFPCollision = true;
            StartCoroutine(stopBackToFalse);
            //col.gameObject.GetComponent<Player>().runSpeed = 20;
        }
    }

    IEnumerator BackToFalse (float delay)
    {
        yield return new WaitForSeconds(delay);
        player.hasLeftFPCollision = false;
        player.runSpeed = 20f;
        print("print");
    }

    void OnPlayerDied()
    {

    }

    void PreparationHasEnded()
    {
        
    }

    void PreparationHasStarted()
    {

    }
}
