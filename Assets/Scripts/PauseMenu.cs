using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioLowPassFilter AudioLowPassFilter;
    public GameObject SettingUI;
    public int currentSceneIndex;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }


    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        PauseMenuUI.SetActive(true);
        LoadAndSaveData.instance.SaveData();
        Time.timeScale = 0;
        AudioLowPassFilter.cutoffFrequency = 540;
        AudioLowPassFilter.lowpassResonanceQ = 2;
        gameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        AudioLowPassFilter.cutoffFrequency = 6700;
        AudioLowPassFilter.lowpassResonanceQ = 1;
        gameIsPaused = false;
        PlayerMovement.instance.enabled = true;
    }

    public void OpenSettingsWindow()
    {
        SettingUI.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        SettingUI.SetActive(false);
    }
    public void LoadMainMenu()
    {

        LoadAndSaveData.instance.SaveStatistics();
        Resume();
        SceneManager.LoadSceneAsync("MainMenu");

    }
}
