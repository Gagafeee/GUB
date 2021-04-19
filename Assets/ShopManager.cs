using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public Animator panelAnimator;
    public GameObject shopPanel;


    public Text cointValue;
    public Image cointImg;
    public Text speedPotionValue;
    public Image speedPotionImg;
    public Text healPotionValue;
    public Image healPotionImg;
    public Text jumpPotionValue;
    public Image jumpPotionImg;

    public Text t1Text1;
    public Text t1Text2;
    private int t1Value1;
    private int t1Value2;
    public Button t1Button;
    public int t1Type;

    private void Awake()
    {
        instance = this;
    }


    void SetTrades()
    {
        //trade1 250 -> 2 speed
        t1Value1 = int.Parse(t1Text1.ToString());
        t1Value2 = int.Parse(t1Text2.ToString());
        if (t1Value1 > CointInventory.instance.coinsCount)
        {
            t1Button.interactable = false;
        }
    }

    void SetInventory()
    {
        cointValue.text = CointInventory.instance.coinsCount.ToString();
        if (CointInventory.instance.coinsCount <= 0)
        {
            cointImg.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);

        }

        speedPotionValue.text = Inventory.inventory.SpeedPotionValue.ToString();
        if (Inventory.inventory.SpeedPotionValue <= 0)
        {
            speedPotionImg.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);

        }
        healPotionValue.text = Inventory.inventory.HealPotionValue.ToString();
        if (Inventory.inventory.HealPotionValue <= 0)
        {
            healPotionImg.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);

        }
        jumpPotionValue.text = Inventory.inventory.JumpPotionValue.ToString();
        if (Inventory.inventory.JumpPotionValue <= 0)
        {
            jumpPotionImg.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);

        }
    }
    
    public void DisplayShop()
    {
        shopPanel.SetActive(true);
        SetInventory();
        SetTrades();
        panelAnimator.SetBool("isVisible", true);
    }

    public void HideShop()
    {
        StartCoroutine(HideShopCor());
    }

    private IEnumerator HideShopCor()
    {
        panelAnimator.SetBool("isVisible", false);
        yield return new WaitForSeconds(1);
        shopPanel.SetActive(false);
    }
}
