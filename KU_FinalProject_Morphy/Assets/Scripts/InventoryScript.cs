using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    GameManager gm;
    [SerializeField] Sprite defaultSprite, selectedSprite;
    int platformNumber;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        ClickablePlatformDefiner.PlatformPlaced.AddListener(PlatformPlaced);
    }

    // Update is called once per frame
    void Update()
    {
        if (platformNumber != gm.platformIDNumber)
        {
            PlatformPlaced();
        }
    }

    public void PlaceRotatingPlatform()
    {
        gm.platformIDNumber = 1;
        platformNumber = 1;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    public void PlaceGravityPlatform()
    {
        gm.platformIDNumber = 2;
        platformNumber = 2;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    public void PlaceJumpPlatform()
    {
        gm.platformIDNumber = 3;
        platformNumber = 3;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    public void PlacePurplePlatform()
    {
        gm.platformIDNumber = 4;
        platformNumber = 4;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    public void PlacePinkPlatform()
    {
        gm.platformIDNumber = 5;
        platformNumber = 5;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    public void PlaceFastPlatfrom()
    {
        gm.platformIDNumber = 6;
        platformNumber = 6;
        gameObject.GetComponent<Image>().sprite = selectedSprite;
    }

    void PlatformPlaced()
    {
        gameObject.GetComponent<Image>().sprite = defaultSprite;
        platformNumber = 0;
    }
}
