using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public Resolution[] resolutions;

    public Slider MusiqueSlider;

    public Slider EffectSlider;

    public void Start()
    {
        audioMixer.GetFloat("Musique", out float musiqueValueForSlider);
        MusiqueSlider.value = musiqueValueForSlider;

        audioMixer.GetFloat("Effect", out float effectValueForSlider);
        EffectSlider.value = effectValueForSlider;


        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Musique", volume);
        PlayerPrefs.SetFloat("setting.sound.musique", volume);
    }
    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("Effect", volume);
        PlayerPrefs.SetFloat("setting.sound.effect", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
    }
}
