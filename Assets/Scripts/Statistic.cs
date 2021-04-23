using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour
{
    public static Statistic Instance;

    public int dead;
    public float damage;
    public float regeneration;
    
    public int speedPotionUse;
    public int healPotionUse;
    public int jumpPotionUse;

    public int speedPotionCollected;
    public int healPotionCollected;
    public int jumpPotionCollected;

    public int jumps;
    public float distanceTraveled;

    public int collectedCoins;

    public bool timerIsActive;
    public int timeS;
    public int timeM;
    public int timeH;

    private void Awake()
    {
        Instance = this;
    }
    
    
    public void AddItems(int itemType, int amount)
    {
        if (itemType == 0)
        {
           
        }
        if (itemType == 1)
        {
            Inventory.inventory.SpeedPotionValue += amount;
            speedPotionCollected += amount;
           
        }
        if (itemType == 2)
        {
            Inventory.inventory.HealPotionValue += amount;
            healPotionCollected += amount;

           
        }
        if (itemType == 3)
        {
            Inventory.inventory.JumpPotionValue += amount;
            jumpPotionCollected  += amount;


        }
    }

    private void Start()
    {
        timeS++;
        timerIsActive = true;
        StartCoroutine(TimerCor());
        
        LoadAndSaveData.instance.LoadStatistics();
    }


    private void Timer()
    {
        if (timerIsActive)
        {
          timeS++;  
          
          if (timeS == 60)
          {
              timeM++;
              timeS = 0;
          }
          if (timeM == 60)
          {
              timeH++;
              timeM = 0;

          } 
        }
        StartCoroutine(TimerCor());
    }

    private IEnumerator TimerCor()
    {
        yield return new WaitForSeconds(1);
        Timer();
        
    }
}
