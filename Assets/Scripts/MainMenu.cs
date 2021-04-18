using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public AudioManager AudioManager;
    public GameObject settingsWindow;

    public int cutoffFrequency = 6700;
    public AudioClip sound;

    public Animator Cameranimator;
    public Animator MenuButtonanimator;
    public Animator CréditButtonanimator;
    public Animator SettingButtonanimator;
    public Animator InGameDebugConsoleAnimator;
    public Animator Tittleanimator;


    public void Start()
    {
        InGameDebugConsoleAnimator = GameObject.Find("DebugLogPopup").GetComponent<Animator>();
        AudioManager.instance.audioMixer.SetFloat("Musique", PlayerPrefs.GetFloat("setting.sound.musique"));
        AudioManager.instance.audioMixer.SetFloat("Effect", PlayerPrefs.GetFloat("setting.sound.effect"));
        StartCoroutine(StartAnnimation());
    }

    public IEnumerator StartAnnimation()
    {
        Cameranimator.SetTrigger("start");
        yield return new WaitForSeconds(0.8f);
        Tittleanimator.SetTrigger("start");
        MenuButtonanimator.SetTrigger("start");
        CréditButtonanimator.SetTrigger("start");
        SettingButtonanimator.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        StartCoroutine(TravelStart.instance.StartTravel());

    }
    public void LoadGame()
    {
        SceneManager.LoadScene(levelToLoad);

    }
    public void SettingsButton()
    {

        settingsWindow.SetActive(true);
        AudioManager.instance.PlayClipAt(sound, transform.position);

    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        AudioManager.instance.PlayClipAt(sound, transform.position);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySound()
    {
        AudioManager.instance.PlayClipAt(sound, transform.position);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsWindow.gameObject.activeSelf)
            {
                CloseSettingsWindow();
            }
        }
    }
}
