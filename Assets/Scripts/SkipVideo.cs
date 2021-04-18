using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour
{
    public void OnVideoTermided()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
