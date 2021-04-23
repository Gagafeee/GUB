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
    public Text speedPotionValue;
    public Text healPotionValue;
    public Text jumpPotionValue;

    public Text t1Text1;
    public Text t1Text2;
    public int t1Value1;
    public int t1Value2;
    public Button t1Button;
    
    public Text t2Text1;
    public Text t2Text2;
    public int t2Value1;
    public int t2Value2;
    public Button t2Button;
    
    public Text t3Text1;
    public Text t3Text2;
    public int t3Value1;
    public int t3Value2;
    public Button t3Button;
    
    public Text t4Text1;
    public Text t4Text2;
    public int t4Value1;
    public int t4Value2;
    public Button t4Button;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetInventory();
        }
    }


    public void Trade(int tradeId)
    {
        switch (tradeId)
        {
            case 0:
                ErrorManager.instance.FataleError("IValueError : Une valeur d'entrer n'est pas bonne","[Type:Persistant] Not Resolved : please talk it to a developer");
                break;
            case 1:
            {
                if (t1Value1 < CointInventory.instance.coinsCount)
                {
                    Inventory.inventory.SpeedPotionValue += t1Value2;
                    CointInventory.instance.coinsCount -= t1Value1;
                    SetInventory();
                    SetTrades();
                }
                else
                {
                    t1Button.interactable = false;
                }
                    
                break;
            }
            case 2:
            {
                if (t2Value1 < CointInventory.instance.coinsCount)
                {
                    Inventory.inventory.HealPotionValue += t2Value2;
                    CointInventory.instance.coinsCount -= t2Value1;
                    SetInventory();
                    SetTrades();
                }
                else
                {
                    t2Button.interactable = false;
                }
                    
                break;
            }
            case 3:
            {
                if (t3Value1 < CointInventory.instance.coinsCount)
                {
                    Inventory.inventory.JumpPotionValue += t3Value2;
                    CointInventory.instance.coinsCount -= t3Value1;
                    SetInventory();
                    SetTrades();
                }
                else
                {
                    t3Button.interactable = false;
                }
                    
                break;
            }
            case 4:
            {
                if (t4Value1 < CointInventory.instance.coinsCount)
                {
                    Inventory.inventory.ItemValue += t4Value2;
                    CointInventory.instance.coinsCount -= t4Value1;
                    SetInventory();
                    SetTrades();
                }
                else
                {
                    t4Button.interactable = false;
                }
                    
                break;
            }
        }
    }

    private void SetTrades()
    {
        //trade1 250 -> 2 speed
        t1Text1.text = t1Value1.ToString();
        t1Text2.text = t1Value2.ToString();
        if(t1Value1 <= 0 || t1Value2 <= 0)
        {
            t1Button.interactable = false;
            ErrorManager.instance.FataleError("Trade price is not Valid [Price<=0]", "Not Corrected please talk it to a developer");
        }
        if (t1Value1 > CointInventory.instance.coinsCount)
        {
            t1Button.interactable = false;
        }
        if(t2Value1 <= 0 || t2Value2 <= 0)
        {
            t2Button.interactable = false;
            ErrorManager.instance.FataleError("Trade price is not Valid [Price<=0]", "Not Corrected please talk it to a developer");
        }
        if (t2Value1 > CointInventory.instance.coinsCount)
        {
            t2Button.interactable = false;
        }
        if(t3Value1 <= 0 || t3Value2 <= 0)
        {
            t3Button.interactable = false;
            ErrorManager.instance.FataleError("Trade price is not Valid [Price<=0]", "Not Corrected please talk it to a developer");
        }
        if (t3Value1 > CointInventory.instance.coinsCount)
        {
            t3Button.interactable = false;
        }
        if(t4Value1 <= 0 || t4Value2 <= 0)
        {
            t4Button.interactable = false;
            ErrorManager.instance.FataleError("Trade price is not Valid [Price<=0]", "Not Corrected please talk it to a developer");
        }
        if (t4Value1 > CointInventory.instance.coinsCount)
        {
            t4Button.interactable = false;
        }
        
    }

    void SetInventory()
    {
        cointValue.text = CointInventory.instance.coinsCount.ToString();
        speedPotionValue.text = Inventory.inventory.SpeedPotionValue.ToString();
        jumpPotionValue.text = Inventory.inventory.JumpPotionValue.ToString();
        healPotionValue.text = Inventory.inventory.HealPotionValue.ToString();
        if (CointInventory.instance.coinsCount <= 0)
        {
            HideShop();
            ErrorManager.instance.FataleError("IUnauthorizedOperation : [Shop]", "please talk it to a developer");
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
