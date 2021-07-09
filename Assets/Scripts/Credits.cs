using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void LoadMaintMenu()
    {
        var audiomanager = GameObject.FindGameObjectWithTag("AudioManager");
        Destroy(audiomanager);
        SceneManager.LoadScene("MainMenu");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMaintMenu();
        }
    }
}
