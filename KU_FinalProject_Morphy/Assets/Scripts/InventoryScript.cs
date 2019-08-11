using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceRotatingPlatform()
    {
        gm.platformIDNumber = 1;
    }

    public void PlaceGravityPlatform()
    {
        gm.platformIDNumber = 2;
    }

    public void PlaceJumpPlatform()
    {
        gm.platformIDNumber = 3;
    }
}
