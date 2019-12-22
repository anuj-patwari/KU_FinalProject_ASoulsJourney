using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneStory : MonoBehaviour
{

    GlobalAudioManager gam;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();

        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            StartCoroutine(SwitchToLevelOne(15));
            gam.secOneAudioCounter = 500;
        }

        else if (SceneManager.GetActiveScene().name == "Section1Completed")
        {
            StartCoroutine(SwitchToLevelTen(15));
            gam.secTwoAudioCounter = 500;
        }

        else if (SceneManager.GetActiveScene().name == "Section2Completed")
        {
            StartCoroutine(SwitchToLevelNineteen(19));
            gam.secThreeAudioCounter = 500;
        }

        else if (SceneManager.GetActiveScene().name == "Section3Completed")
        {
            StartCoroutine(SwitchToCredits(27));
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SwitchToLevelOne(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator SwitchToLevelTen(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level10");
    }

    IEnumerator SwitchToLevelNineteen(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level19");
    }

    IEnumerator SwitchToCredits(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Credits");
    }
}
