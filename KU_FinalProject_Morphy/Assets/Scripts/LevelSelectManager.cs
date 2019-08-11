using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    GlobalAudioManager gam;

    [SerializeField] GameObject lvl1Button, lvl2Button, lvl3Button, lvl4Button, lvl5Button, lvl6Button, lvl7Button, lvl8Button, lvl9Button, lvl10Button;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();

        if (gam.levelsCompleted > 0)
        {
            lvl2Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 1)
        {
            lvl3Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 2)
        {
            lvl4Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 3)
        {
            lvl5Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 4)
        {
            lvl6Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 5)
        {
            lvl7Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 6)
        {
            lvl8Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 7)
        {
            lvl9Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 8)
        {
            lvl10Button.GetComponent<Button>().interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
