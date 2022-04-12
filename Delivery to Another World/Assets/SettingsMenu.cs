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
        slider.value = volume * 100f;
    }

    public void changeVolume()
    {
        float newVolume = slider.value;
        AudioListener.volume = newVolume/50f;
        PlayerPrefs.SetFloat("volume", newVolume/50f);
    }

    public void exitMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
