using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneStory : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "IntroScene")
        {
            StartCoroutine(SwitchToLevelOne(15));
        }

        else if (SceneManager.GetActiveScene().name == "Section1Completed")
        {
            StartCoroutine(SwitchToLevelTen(15));
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
}
