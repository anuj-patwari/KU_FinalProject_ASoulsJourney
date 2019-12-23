using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    GlobalAudioManager gam;

    [SerializeField] GameObject lvl1Button, lvl2Button, lvl3Button, lvl4Button, lvl5Button, lvl6Button, lvl7Button, lvl8Button, lvl9Button, lvl10Button, lvl11Button, lvl12Button, lvl13Button, lvl14Button, lvl15Button, lvl16Button, lvl17Button, lvl18Button, lvl19Button, lvl20Button, lvl21Button, lvl22Button, lvl23Button, lvl24Button, lvl25Button, lvl26Button, lvl27Button, lvl28Button;

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

        if (gam.levelsCompleted > 9)
        {
            lvl11Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 10)
        {
            lvl12Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 11)
        {
            lvl13Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 12)
        {
            lvl14Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 13)
        {
            lvl15Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 14)
        {
            lvl16Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 15)
        {
            lvl17Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 16)
        {
            lvl18Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 17)
        {
            lvl19Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 18)
        {
            lvl20Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 19)
        {
            lvl21Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 20)
        {
            lvl22Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 21)
        {
            lvl23Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 22)
        {
            lvl24Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 23)
        {
            lvl25Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 24)
        {
            lvl26Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 25)
        {
            lvl27Button.GetComponent<Button>().interactable = true;
        }

        if (gam.levelsCompleted > 26)
        {
            lvl28Button.GetComponent<Button>().interactable = true;
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
