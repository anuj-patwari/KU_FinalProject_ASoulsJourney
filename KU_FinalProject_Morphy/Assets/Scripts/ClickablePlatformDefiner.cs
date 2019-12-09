using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickablePlatformDefiner : MonoBehaviour
{
    public Vector2 position;
    [SerializeField] GameObject rotatingPlatform;
    [SerializeField] GameObject gravityPlatform;
    [SerializeField] GameObject jumpPlatform;
    [SerializeField] GameObject purplePlatform;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        GameManager.PrepPhaseEnded.AddListener(PreparationHasEnded);
        GameManager.PrepPhaseStarted.AddListener(PreparationHasStarted);
        gameObject.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.prepPhase == true && gm.platformIDNumber != 0)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        else if (gm.prepPhase == true && gm.platformIDNumber == 0)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(gm.platformIDNumber == 1 && gm.rotatingPlatformCount > 0)
        {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            GameObject platformToBePlaced = (GameObject)Instantiate(rotatingPlatform, position, transform.rotation);
            Destroy(gameObject);
            gm.platformIDNumber = 0;
            rotatingPlatform.GetComponent<RotatingPlatform>().placed = true;
            gm.rotatingPlatformCount = gm.rotatingPlatformCount - 1;
            gm.rotatingPlatformCountText.GetComponent<Text>().text = gm.rotatingPlatformCount.ToString();
        }

        if (gm.platformIDNumber == 2 && gm.gravityPlatformCount > 0)
        {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            GameObject platformToBePlaced = (GameObject)Instantiate(gravityPlatform, position, transform.rotation);
            gameObject.SetActive(false);
            gm.platformIDNumber = 0;
            gravityPlatform.GetComponent<pCheckGravityPlatform>().placed = true;
            gm.gravityPlatformCount = gm.gravityPlatformCount - 1;
            gm.gravityPlatformCountText.GetComponent<Text>().text = gm.gravityPlatformCount.ToString();
        }

        if (gm.platformIDNumber == 3 && gm.jumpPlatformCount > 0)
        {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            GameObject platformToBePlaced = (GameObject)Instantiate(jumpPlatform, position, transform.rotation);
            Destroy(gameObject);
            gm.platformIDNumber = 0;
            jumpPlatform.GetComponent<JumpPlatform>().placed = true;
            gm.jumpPlatformCount = gm.jumpPlatformCount - 1;
            gm.jumpPlatformCountText.GetComponent<Text>().text = gm.jumpPlatformCount.ToString();
        }

        if (gm.platformIDNumber == 4 && gm.purplePlatformCount > 0)
        {
            position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            GameObject platformToBePlaced = (GameObject)Instantiate(purplePlatform, position, transform.rotation);
            Destroy(gameObject);
            gm.platformIDNumber = 0;
            purplePlatform.GetComponent<ColouredPlatforms>().placed = true;
            purplePlatform.GetComponent<ColouredPlatforms>().platformColor = 2;
            gm.purplePlatformCount = gm.purplePlatformCount - 1;
            gm.purplePlatformCountText.GetComponent<Text>().text = gm.purplePlatformCount.ToString();
        }

    }

    void PreparationHasEnded()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    void PreparationHasStarted()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
