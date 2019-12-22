using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    GameManager gm;
    CharacterController2D cc2d;
    InventoryCountDefiner invCount;
    public GameObject getKeyText;

    GlobalAudioManager gam;
    Player player;

    [SerializeField] Sprite keyRequired, keyNotRequired;

    int changeLevel = 0;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
        cc2d = FindObjectOfType<CharacterController2D>();
        invCount = FindObjectOfType<InventoryCountDefiner>();

        rb = FindObjectOfType<Rigidbody2D>();

        if (gm.hasKey == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = keyNotRequired;
        }

        else if (gm.hasKey == false)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = keyRequired;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (changeLevel > 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 1.2f, Time.deltaTime * 4);
            changeLevel--;
        }

        if(changeLevel == 1)
        {
            changeLevel = -60;
        }

        if (changeLevel < 0)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 0, Time.deltaTime * 8);
            player.transform.localScale = Vector3.Lerp(player.transform.localScale, player.transform.localScale * 0, Time.deltaTime * 8);
            changeLevel++;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gm.levelNumber != 27)
        {
            if (col.gameObject.name == "Player")
            {
                if (gm.hasKey == true)
                {
                    changeLevel = 60;
                    StartCoroutine(DisablePlayerMovement(0.2f));
                    StartCoroutine(NextLevel(1));
                    if(gm.levelNumber > gam.levelsCompleted)
                    {
                        gam.levelsCompleted = gm.levelNumber;
                    }
                    gam.SaveGame();
                }

                else if (gm.hasKey == false)
                {
                    getKeyText.GetComponent<Text>().enabled = true;
                    StartCoroutine(DeactivateText(3));
                }
            }
        }
        else if (gm.levelNumber == 27)
        {
            if (col.gameObject.name == "Player")
            {
                if (gm.hasKey == true)
                {
                    SceneManager.LoadScene("Credits");
                    gam.SaveGame();
                }

                else if (gm.hasKey == false)
                {
                    getKeyText.GetComponent<Text>().enabled = true;
                    StartCoroutine(DeactivateText(3));
                }
            }
        }
    }

    IEnumerator DeactivateText(float delay)
    {
        yield return new WaitForSeconds(delay);
        getKeyText.GetComponent<Text>().enabled = false;
    }

    IEnumerator DisablePlayerMovement(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    IEnumerator NextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(gm.nextLevel);
    }
}
