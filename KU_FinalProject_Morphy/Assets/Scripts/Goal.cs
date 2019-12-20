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

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        gm = FindObjectOfType<GameManager>();
        cc2d = FindObjectOfType<CharacterController2D>();
        invCount = FindObjectOfType<InventoryCountDefiner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (gm.levelNumber != 27)
        {
            if (col.gameObject.name == "Player")
            {
                if (gm.hasKey == true)
                {
                    SceneManager.LoadScene(gm.nextLevel);
                    if(gm.levelNumber > gam.levelsCompleted)
                    {
                        gam.levelsCompleted = gm.levelNumber;
                    }
                    gam.SaveGame();
                }

                else if (gm.hasKey == false)
                {
                    getKeyText.GetComponent<Image>().enabled = true;
                    StartCoroutine(DeactivateText(3));
                }
            }
        }
        else if (gm.levelNumber == 27)
        {
            SceneManager.LoadScene("Credits");
        }
        
    }

    IEnumerator DeactivateText(float delay)
    {
        yield return new WaitForSeconds(delay);
        getKeyText.GetComponent<Image>().enabled = false;
    }
}
