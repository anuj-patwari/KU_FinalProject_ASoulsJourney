using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    GameManager gm;

    [SerializeField] GameObject playPhaseText, prepPhaseText, clickPlatformText, placePlatformText, controlsText;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            clickPlatformText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if(gm.platformIDNumber != 0 && clickPlatformText.activeInHierarchy)
            {
                clickPlatformText.SetActive(false);
                placePlatformText.SetActive(true);
                StartCoroutine(IncreaseCount(0.5f));
            }
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (gm.platformIDNumber == 0 && placePlatformText.activeInHierarchy && count == 1)
                {
                    placePlatformText.SetActive(false);
                    playPhaseText.SetActive(true);
                    StartCoroutine(IncreaseCount(0.5f));
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (Input.GetKeyUp (KeyCode.Tab))
            {
                if (gm.platformIDNumber == 0 && playPhaseText.activeInHierarchy && count == 2)
                {
                    playPhaseText.SetActive(false);
                    controlsText.SetActive(true);
                    StartCoroutine(IncreaseCount(0.5f));
                    StartCoroutine(HideControls(10f));
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                if (gm.prepPhase == false && count == 0)
                {
                    StartCoroutine(ShowPrepPhaseTutorialText(5));
                    count = 1;
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Level6")
        {
            if (Input.GetKeyUp(KeyCode.Tab) && prepPhaseText.activeInHierarchy && count == 1)
            {
                prepPhaseText.SetActive(false);
                count = 2;
            }
        }

    }

    IEnumerator IncreaseCount(float delay)
    {
        yield return new WaitForSeconds(delay);
        count++;
    }

    IEnumerator HideControls(float delay)
    {
        yield return new WaitForSeconds(delay);
        controlsText.SetActive(false);
    }

    IEnumerator ShowPrepPhaseTutorialText(float delay)
    {
        yield return new WaitForSeconds(delay);
        prepPhaseText.SetActive(true);
        StartCoroutine(DisablePrepText(5f));
    }

    IEnumerator DisablePrepText(float delay)
    {
        yield return new WaitForSeconds(delay);
        prepPhaseText.SetActive(false);
        count = 2;
    }
}
