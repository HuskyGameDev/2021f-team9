using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Slider slider;

    private void Start()
    {
        settingsMenu.SetActive(false);
        float volume = PlayerPrefs.GetFloat("volume");
        AudioListener.volume = volume;
        slider.value = volume;
    }

    public void changeVolume()
    {
        float newVolume = slider.value;
        AudioListener.volume = newVolume;
        PlayerPrefs.SetFloat("volume", newVolume);
    }

    public void exitMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
