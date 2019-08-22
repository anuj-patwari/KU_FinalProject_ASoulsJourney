using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
}
