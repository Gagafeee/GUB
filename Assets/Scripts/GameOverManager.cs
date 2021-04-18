using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager instance;
    public AudioLowPassFilter AudioLowPassFilter;
    public CointInventory Inventory;
    public AudioClip sound;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        CointInventory.instance.RemoveCoins(CointInventory.instance.coinsCount / 2);
        AudioSource.PlayClipAtPoint(sound, transform.position);
        AudioLowPassFilter.cutoffFrequency = 145;
        gameOverUI.SetActive(true);
        LoadAndSaveData.instance.SaveData();


    }

    public void RetryButton()
    {
        AudioLowPassFilter.cutoffFrequency = 6700;
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "StartPosX", -46);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "StartPosY", 3);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "StartPosZ", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
