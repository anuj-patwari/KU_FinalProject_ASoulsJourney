using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastPlatform : MonoBehaviour
{

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
        if (player.hasLeftFPCollision == true)
        {
            if (player.runSpeed > 20)
            {
                player.runSpeed -= Time.deltaTime * 8f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.hasLeftFPCollision = false;
        player.StoppingFalseCoroutine();
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
            player.SettingCollisionToFalse();
        }
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
