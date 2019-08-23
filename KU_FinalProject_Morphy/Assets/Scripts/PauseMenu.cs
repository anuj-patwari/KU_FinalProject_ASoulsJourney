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

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
        volumeSlider.GetComponent<Slider>().value = gam.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AdjustVolume(float volume)
    {
        gam.GetComponent<AudioSource>().volume = volume;
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
