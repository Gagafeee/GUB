using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine.UI;

public class EndLevelPanelManager : MonoBehaviour
{
    public static EndLevelPanelManager Instance;
    public Animator panelAnimator;
    public GameObject panel;
    
    
    public Text collectedCoinsValue;
    
    public Text deadValue;
    public Text damageValue;
    public Text regenerationValue;
  
    public Text speedPotionUseValue;
    public Text speedPotionCollectedValue;
    
    public Text healPotionUseValue;
    public Text healPotionCollectedValue;
    
    public Text jumpPotionUseValue;
    public Text jumpPotionCollectedValue;
    
    public Text jumpsValue;
    
    public Text distanceTraveledValue;
    
    public Text timeValue;
    public void Awake()
    {
        Instance = this;
    }


    public void SetStats()
    {
        Statistic.Instance.distanceTraveled = PlayerMovement.instance.Player.transform.position.x - 46;


        deadValue.text = Statistic.Instance.dead.ToString();
        damageValue.text = Statistic.Instance.damage.ToString();
        regenerationValue.text = Statistic.Instance.regeneration.ToString();

        speedPotionCollectedValue.text = Statistic.Instance.speedPotionCollected.ToString();
        speedPotionUseValue.text = Statistic.Instance.speedPotionUse.ToString();
        healPotionCollectedValue.text = Statistic.Instance.healPotionCollected.ToString();
        healPotionUseValue.text = Statistic.Instance.healPotionUse.ToString();
        jumpPotionCollectedValue.text = Statistic.Instance.jumpPotionCollected.ToString();
        jumpPotionUseValue.text = Statistic.Instance.jumpPotionUse.ToString();

        jumpsValue.text = Statistic.Instance.jumps.ToString();
        distanceTraveledValue.text = Statistic.Instance.distanceTraveled.ToString();
        collectedCoinsValue.text = Statistic.Instance.collectedCoins.ToString();

        timeValue.text = "Time : " + (00 + Statistic.Instance.timeH) + ":" + (00 + Statistic.Instance.timeM) + ":" +
                         (00 + Statistic.Instance.timeS);

    }

    public void DisplayPanel()
    {
        //SetStats();
        StartCoroutine(DisplayPanelCor());
    }
    
    private IEnumerator DisplayPanelCor()
    {
        panel.SetActive(true);
        panelAnimator.SetBool("isVisible", true);
        yield return new WaitForSeconds(1.30f);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(NextLevelCor());
    }

    private IEnumerator NextLevelCor()
    { 
        panelAnimator.SetBool("isVisible", false);
        yield return new WaitForSeconds(0.5f);
        LoadSpecificScene.instance.loadScene(1, false);
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }
}
