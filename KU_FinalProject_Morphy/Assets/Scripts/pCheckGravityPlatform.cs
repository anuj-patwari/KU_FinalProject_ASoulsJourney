using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pCheckGravityPlatform : MonoBehaviour
{

    public bool placed = false;
    public GameObject crossButton;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        GameManager.PrepPhaseEnded.AddListener(RemoveCrosses);
        GameManager.PrepPhaseStarted.AddListener(EnableCrosses);
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
        
    }

    void RemoveCrosses()
    {
        crossButton.SetActive(false);
    }

    void EnableCrosses()
    {
        if(placed == true)
        {
            crossButton.SetActive(true);
        }
    }
}
