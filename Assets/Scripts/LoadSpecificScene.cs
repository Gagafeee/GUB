using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public Animator fadeSystem;
    public AudioClip sound;
    public static LoadSpecificScene instance;
    private void Awake()
    {
            fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        instance = this;
        return;
        
    }
    
    
    /*LevelType :
     0 = menu
     1 = next game scene
     2 = crédit scene
     */ 
    public void loadScene(int LevelType, bool displayFadeOut)
    {
        
        if (LevelType == 0)
        {
            StartCoroutine(loadMenuScene());

        }

        if (LevelType == 1)
        {
            CurrentSceneManager.instance.RespawnPoint = new Vector3(-46, 3, 0);
            CurrentSceneManager.instance.isTheFirstEnterInLevel = true;
            LoadAndSaveData.instance.SaveData();
            StartCoroutine(loadNextGameScene(displayFadeOut));

        }

        if (LevelType == 2)
        {
            StartCoroutine(loadCreditScene());

        }

        ErrorManager.instance.Error("test", "test");

    }


    public IEnumerator loadMenuScene()
    {
        /*set graphique + sound*/
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("MainMenu");
        
    }
    
    
    public IEnumerator loadNextGameScene(bool displayFadeOut)
    {
        //set graphic + sound
        AudioManager.instance.PlayClipAt(sound, transform.position);
        if (displayFadeOut)
        {
            yield return new WaitForSeconds(0.7f);
            fadeSystem.SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f); 
        }
        
        
        int nextLevelId = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelId > Levelmanager.instance.levelIndex)
        {
            StartCoroutine(loadCreditScene());
        }
        else if (nextLevelId <= Levelmanager.instance.levelIndex)
        {
            SceneManager.LoadSceneAsync(nextLevelId);
        }
        
    }

    public IEnumerator loadCreditScene()
    {
        AudioManager.instance.PlayClipAt(sound, transform.position);
        yield return new WaitForSeconds(0.7f);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadSceneAsync("Credits");
    }
}
