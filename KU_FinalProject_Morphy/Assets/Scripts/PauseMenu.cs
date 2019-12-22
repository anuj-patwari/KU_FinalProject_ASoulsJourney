using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    GlobalAudioManager gam;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        gm = FindObjectOfType<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.levelNumber < 10)
        {
            volumeSlider.GetComponent<Slider>().value = gam.GetComponent<AudioSource>().volume;
        }

        else if (gm.levelNumber > 9 && gm.levelNumber < 19)
        {
            volumeSlider.GetComponent<Slider>().value = gam.sectionTwoAudio.GetComponent<AudioSource>().volume;
        }

        else if (gm.levelNumber > 18)
        {
            volumeSlider.GetComponent<Slider>().value = gam.sectionThreeAudio.GetComponent<AudioSource>().volume;
        }
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
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
