using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    GlobalAudioManager gam;

    // Start is called before the first frame update
    void Start()
    {
        gam = FindObjectOfType<GlobalAudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustVolume(float volume)
    {
        //audioMixer.SetFloat("masterVolume", volume);
        gam.GetComponent<AudioSource>().volume = volume;
    }
}
