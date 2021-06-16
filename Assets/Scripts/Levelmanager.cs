using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    public static Levelmanager instance;
    //last level unloked
    public int lastLevelUnloked;
    //Actual Level Id
    public int actualLevel = 1;
    
    public int levelIndex;


    public void Awake()
    {
        instance = this;
  
    }

    public void Start()
    {
        
        
        
        actualLevel = lastLevelUnloked;
        if (actualLevel < 0)
        {
            actualLevel = 0;
            PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "Levelunloked", 0);
            ErrorManager.instance.FataleError("Vous ne pouvez pas jouer le niveau -1 [levelUnloked.value < 0]",
                "Corrected (restart your game)");

        }

    }

    public void Update()
    {
        actualLevel = SceneManager.GetActiveScene().buildIndex;
    }
}
