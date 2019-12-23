using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Slider volumeSlider;
    GlobalAudioManager gam;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        gm = FindObjectOfType<GameManager>();

        //volumeSlider.GetComponent<Slider>().value = gam.masterVolume;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume(float volume)
    {
        if (gm.levelNumber < 10)
        {
            gam.GetComponent<AudioSource>().volume = volume;
        }

        else if (gm.levelNumber > 9 && gm.levelNumber < 19)
        {
            gam.sectionTwoAudio.GetComponent<AudioSource>().volume = volume;
        }

        else if (gm.levelNumber > 18)
        {
            gam.sectionThreeAudio.GetComponent<AudioSource>().volume = volume;
        }
        //gam.masterVolume = volumeSlider.GetComponent<Slider>().value;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        gam.masterVolume = volumeSlider.GetComponent<Slider>().value;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
