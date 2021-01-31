using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public AudioMixer musicMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioSource source;
    public AudioClip buttonPress;

    // Start is called before the first frame update
    void Start()
    {
        Back();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        source.Play();
    }

    public void StartGame()
    {
        source.Play();
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        source.Play();
    }

    public void SetMusicVolume(float vol)
    {
        musicMixer.SetFloat("MusicVol", Mathf.Log10(vol) * 20);
    }

    public void SetSFXVolume(float vol)
    {
        musicMixer.SetFloat("SFXVol", Mathf.Log10(vol) * 20);
    }
}
