using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveGravityPlatform : MonoBehaviour
{
    public Vector2 position;
    public GameObject platform;
    public GameObject platformPlacer;

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

    private void OnMouseDown()
    {
        if (platform.GetComponent<pCheckGravityPlatform>().placed == true)
        {
            position = new Vector2(platform.transform.position.x, platform.transform.position.y);
            GameObject platformToBePlaced = (GameObject)Instantiate(platformPlacer, position, transform.rotation);
            Destroy(platform);
            gm.platformIDNumber = 0;
            gm.gravityPlatformCount = gm.gravityPlatformCount + 1;
            gm.gravityPlatformCountText.GetComponent<Text>().text = gm.gravityPlatformCount.ToString();
        }

    }
}
