using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pCheckFastPlatform : MonoBehaviour
{
    GameManager gm;

    public bool placed;
    [SerializeField] GameObject cross;

    // Start is called before the first frame update
    void Start()
    {
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
