using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class HowToPlayManager : MonoBehaviour
{
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject howToPlayText;
    [SerializeField] GameObject controlsText;
    [SerializeField] GameObject letsGoButton;

    private int menuNumber;

    GlobalAudioManager gam;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();

        menuNumber = 1;
        leftButton.SetActive(false);
        howToPlayText.SetActive(true);
        controlsText.SetActive(false);
        letsGoButton.SetActive(false);
        rightButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchButtonClicked()
    {
        if (menuNumber == 1)
        {
            rightButton.SetActive(false);
            howToPlayText.SetActive(false);
            controlsText.SetActive(true);
            letsGoButton.SetActive(true);
            leftButton.SetActive(true);
            menuNumber = 2;
        }

        else if (menuNumber == 2)
        {
            leftButton.SetActive(false);
            howToPlayText.SetActive(true);
            controlsText.SetActive(false);
            letsGoButton.SetActive(false);
            rightButton.SetActive(true);
            menuNumber = 1;
        }
    }

    public void StartGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            gam.LoadGame();
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
