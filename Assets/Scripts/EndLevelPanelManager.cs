using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
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

    public Text title;
    
    public Text timeSValue;
    public Text timeMValue;
    public Text timeHValue;
    public void Awake()
    {
        Instance = this;
    }


    public void SetStats()
    {
        var p = PlayerMovement.instance.Player.transform.position.x - -46;
        Statistic.Instance.distanceTraveled = Mathf.Abs(p);

        title.text = "Bravo, Vous avez Terminez le niveau " + SceneManager.GetActiveScene().buildIndex;
        
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



        if (Statistic.Instance.timeH >= 10)
        {
            timeHValue.text = Statistic.Instance.timeH.ToString();
        }

        if (Statistic.Instance.timeH < 10)
        {
            timeHValue.text = "0" + Statistic.Instance.timeH;
        }


        if (Statistic.Instance.timeM >= 10)
        {
            timeMValue.text = Statistic.Instance.timeM.ToString();
        }

        if (Statistic.Instance.timeM < 10)
        {
            timeMValue.text = "0" + Statistic.Instance.timeM;
        }

        if (Statistic.Instance.timeS >= 10)
        {
            timeSValue.text = Statistic.Instance.timeS.ToString();
        }

        if (Statistic.Instance.timeS < 10)
        {
            timeSValue.text = "0" + Statistic.Instance.timeS;
        }

        
        


    }

    public void DisplayPanel()
    {
        SetStats();
        StartCoroutine(DisplayPanelCor());
    }
    
    private IEnumerator DisplayPanelCor()
    {
        panel.SetActive(true);
        panelAnimator.SetBool("isVisible", true);
        yield return new WaitForSeconds(1.30f);
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovement.instance.rb.velocity = Vector3.zero;
        PlayerMovement.instance.playerCollider.enabled = false;
        PlayerMovement.instance.moveSpeed = 0;
    }

    public void NextLevel()
    {
        PlayerMovement.instance.playerCollider.enabled = true;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovement.instance.moveSpeed = 150;
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
