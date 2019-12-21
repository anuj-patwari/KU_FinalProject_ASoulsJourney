using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    int timer;
    [SerializeField] GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > -1)
        {
            timer--;
        }
        else if (timer != 0)
        {
            //timer = 0;
        }

        if (timer == 0)
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
            {
                gameObject.GetComponent<MainMenuSaveStateManager>().enabled = true;
            }
        }
    }

    public void StartGame()
    {
        canvas.GetComponent<Animator>().enabled = true;
        StartCoroutine(SwitchScene(0.85f));
    }

    IEnumerator SwitchScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("IntroScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
