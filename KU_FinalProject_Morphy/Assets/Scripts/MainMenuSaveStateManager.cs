using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenuSaveStateManager : MonoBehaviour
{
    [SerializeField] GameObject mainGroup;
    [SerializeField] GameObject saveStateGroup;

    GlobalAudioManager gam;
    MainMenuManager mmm;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        mmm = FindObjectOfType<MainMenuManager>();
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            if (gam.levelsCompleted > 0 || gam.deaths > 0)
            {
                saveStateGroup.SetActive(true);
                mainGroup.SetActive(false);
            }
            else if (gam.levelsCompleted == 0 && gam.deaths == 0)
            {
                saveStateGroup.SetActive(false);
                mainGroup.SetActive(true);
            }
        }
        else
        {
            saveStateGroup.SetActive(false);
            mainGroup.SetActive(true);
        }

       /*if (gam.levelsCompleted == 0)
        {
            saveStateGroup.SetActive(false);
            mainGroup.SetActive(true);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGame()
    {
        gam.NewGame();
        mmm.StartGame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

}
