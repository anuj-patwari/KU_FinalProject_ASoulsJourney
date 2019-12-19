using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlatform : MonoBehaviour
{

    public bool hasLeftCollision = false;
    Player player;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();

        Player.PlayerDied.AddListener(OnPlayerDied);
        GameManager.PrepPhaseStarted.AddListener(PreparationHasStarted);
        GameManager.PrepPhaseEnded.AddListener(PreparationHasEnded);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLeftCollision == true)
        {
            if (player.runSpeed > 20)
            {
                player.runSpeed -= Time.deltaTime * 30f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<Player>().runSpeed = 80;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            hasLeftCollision = true;
            StartCoroutine(BackToFalse(3));
            //col.gameObject.GetComponent<Player>().runSpeed = 20;
        }
    }

    IEnumerator BackToFalse (float delay)
    {
        yield return new WaitForSeconds(delay);
        hasLeftCollision = false;
        player.runSpeed = 20f;
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
