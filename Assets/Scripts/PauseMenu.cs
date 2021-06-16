using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject PauseMenuUI;
    public AudioLowPassFilter AudioLowPassFilter;
    public GameObject SettingUI;
    public int currentSceneIndex;
    public Animator PanelAnimator;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == true)
            {
                StartCoroutine(Resume());
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
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        PanelAnimator.SetBool("isActive", true);
        LoadAndSaveData.instance.SaveData();
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        PlayerMovement.instance.moveSpeed = 0;
        AudioLowPassFilter.cutoffFrequency = 540;
        AudioLowPassFilter.lowpassResonanceQ = 2;
        gameIsPaused = true;
    }

    public IEnumerator Resume()
    {
        // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
        PanelAnimator.SetBool("isActive", true);
        yield return new WaitForSeconds(1);
        PauseMenuUI.SetActive(false);
        PlayerMovement.instance.playerCollider.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.moveSpeed = 150;
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
        StartCoroutine(Resume());
        SceneManager.LoadSceneAsync("MainMenu");

    }
}
