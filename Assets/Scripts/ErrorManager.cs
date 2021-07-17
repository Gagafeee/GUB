using System;
using System.Diagnostics;
using System.IO;
using IngameDebugConsole;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Application;
using Debug = UnityEngine.Debug;

public class ErrorManager : MonoBehaviour
{
    public bool developperMode;
    public static ErrorManager instance;
    public GameObject FatalScreen;
    public Text FatalReason;
    public Text FatalStatue;
    public GameObject audioManager;
    public GameObject Console;
    public Animator ConsoleAnimator;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Console = GameObject.FindGameObjectWithTag("Console");
        ConsoleAnimator = GameObject.FindGameObjectWithTag("Console").GetComponent<Animator>();

        if (!PlayerPrefs.HasKey("null"))
        {
            PlayerPrefs.SetInt("null",0);
           //Error("Application.Data.Error : Missing File [playerdata]", "Solved");
        }
        
        if (!PlayerPrefs.HasKey("Player0"))
        {
            PlayerPrefs.SetString("Player0","Partie 0");
            //ErrorManager.instance.Error("Application.Data.Error : Missing Player[0]", "Solved");
            CharacterManager.instance.DeletePlayer0(false);
            CharacterManager.instance.play0();
        }


    }

    public void refresh()
    {
        if (developperMode == true)
        {
            MyNotifications.CallNotification("Le developperMode est activée !", 3f);
        }

    }
    void Update()
    {
        Console = GameObject.FindGameObjectWithTag("Console");
        ConsoleAnimator = GameObject.FindGameObjectWithTag("Console").GetComponent<Animator>();
        
        if (Input.GetKeyDown(KeyCode.W) && developperMode == false)
        {
            developperMode = true;
            ConsoleAnimator.SetBool("isVisible", true);


            refresh();

        }
        else if (Input.GetKeyDown(KeyCode.W) && developperMode == true)
        {
            developperMode = false;
            MyNotifications.CallNotification("Le developperMode est desactivée !", 3f);
            ConsoleAnimator.SetBool("isVisible", false);
            refresh();

        }



    }
    public void FataleError(string reason, string statue)
    {
        FatalScreen.SetActive(true);
        FatalReason.text = reason;
        FatalStatue.text = "Statue: " + statue;
        audioManager.SetActive(false);
        Time.timeScale = 0;

    }

    public void Error(string reason, string statue)
    {
        MyNotifications.CallNotification("Error : " + reason + "/" + statue, 5);
        Debug.LogError("Une erreur est survenue Error : " + reason + "  /  " + statue + "  /  " +
                       "Il est conseillé de relancer votre jeu si le problème perciste contactez un développeur ");
    }
}
