using System;
using System.Collections;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public static PotionManager Instance;
    public Sprite EmptyPotion;
    public int i;
    public GameObject Camera;
    public Animator Cameranimator;
    public HealthBar HeartFill;

    public bool SpeedPotionIsInUse;
    public int SpeedPotionUseTime = 30;
    public int SpeedPotionColdownTime = 10;
    public Sprite SpeedPotion1;
    public Sprite SpeedPotion2;
    public Sprite SpeedPotion3;
    public Sprite SpeedPotion4;
    public Sprite SpeedPotion5;

    public bool HealPotionIsInUse;
    public int HealPotionUseTime = 30;
    public int HealPotionColdownTime = 10;
    public Sprite HealPotion1;
    public Sprite HealPotion2;
    public Sprite HealPotion3;
    public Sprite HealPotion4;
    public Sprite HealPotion5;


    public bool JumpPotionIsInUse;
    public int JumpPotionUseTime = 30;
    public int JumpPotionColdownTime = 10;
    public Sprite JumpPotion1;
    public Sprite JumpPotion2;
    public Sprite JumpPotion3;
    public Sprite JumpPotion4;
    public Sprite JumpPotion5;

    public void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Cameranimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    public void SpeedPotionUse()
    {

        SpeedPotionIsInUse = true;
        Statistic.Instance.speedPotionUse++;
        Inventory.inventory.SpeedPotionScreen.SetActive(true);
        Inventory.inventory.SpeedPotionScreenTimeGameObject.SetActive(true);
        Inventory.inventory.SpeedPotionScreenImageGameObject.SetActive(true);
        Inventory.inventory.SpeedPotionValue = Inventory.inventory.SpeedPotionValue - 1;
        LoadAndSaveData.instance.SaveData();
        Inventory.inventory.SpeedPotionTimeGameObject.SetActive(true);
        Inventory.inventory.SpeedPotionUseButton.SetActive(true);
        Inventory.inventory.CloseInventory();
        Cameranimator.SetBool("Is Speed", true);
        PlayerMovement.instance.moveSpeed = 250f;
        StartCoroutine(SpeedPotionUsing());


    }
    public void HealPotionUse()
    {
        HealPotionIsInUse = true;
        Statistic.Instance.healPotionUse++;
        Inventory.inventory.HealPotionValue = Inventory.inventory.HealPotionValue - 1;
        LoadAndSaveData.instance.SaveData();
        Inventory.inventory.HealPotionTimeGameObject.SetActive(true);
        Inventory.inventory.HealPotionUseButton.SetActive(true);
        Inventory.inventory.HealPotionScreen.SetActive(true);
        Inventory.inventory.HealPotionScreenImageGameObject.SetActive(true);
        Inventory.inventory.HealPotionScreenTimeGameObject.SetActive(true);
        Inventory.inventory.CloseInventory();
        HeartFill.SetMaxHealth(250);
        Statistic.Instance.regeneration += 250;
        PlayerHealth.instance.maxHealth = 250;
        PlayerHealth.instance.currentHealth = 250;
        StartCoroutine(HealPotionUsing());
    }
    public void JumpPotionUse()
    {
        JumpPotionIsInUse = true;
        Statistic.Instance.jumpPotionUse++;
        Inventory.inventory.JumpPotionValue = Inventory.inventory.JumpPotionValue - 1;
        LoadAndSaveData.instance.SaveData();
        Inventory.inventory.JumpPotionTimeGameObject.SetActive(true);
        Inventory.inventory.JumpPotionUseButton.SetActive(true);
        Inventory.inventory.JumpPotionScreen.SetActive(true);
        Inventory.inventory.JumpPotionScreenImageGameObject.SetActive(true);
        Inventory.inventory.JumpPotionScreenTimeGameObject.SetActive(true);
        Inventory.inventory.CloseInventory();
        PlayerMovement.instance.jumpForce = 450f;
        StartCoroutine(JumpPotionUsing());
    }



    public IEnumerator HealPotionUsing()
    {
        i = HealPotionUseTime;
        int p = i / 5;

        while (i >= 0)
        {
            if (i >= 10)
            {
                Inventory.inventory.HealPotionTime.text = "0:" + i.ToString();
                Inventory.inventory.HealPotionScreenTime.text = "0:" + i.ToString();
            }
            if (i < 10)
            {
                Inventory.inventory.HealPotionTime.text = "0:0" + i.ToString();
                Inventory.inventory.HealPotionScreenTime.text = "0:0" + i.ToString();
            }


            if (i == p)
            {
                Inventory.inventory.HealPotionImage.sprite = HealPotion1;
                Inventory.inventory.HealPotionScreenImage.sprite = HealPotion1;
            }
            if (i == p + p)
            {
                Inventory.inventory.HealPotionImage.sprite = HealPotion2;
                Inventory.inventory.HealPotionScreenImage.sprite = HealPotion2;

            }
            if (i == p + p + p)
            {
                Inventory.inventory.HealPotionImage.sprite = HealPotion3;
                Inventory.inventory.HealPotionScreenImage.sprite = HealPotion3;

            }
            if (i == p + p + p + p)
            {
                Inventory.inventory.HealPotionImage.sprite = HealPotion4;
                Inventory.inventory.HealPotionScreenImage.sprite = HealPotion4;
                PlayerHealth.instance.currentHealth += 50;
                Statistic.Instance.regeneration += 50;

            }
            if (i == p + p + p + p + p)
            {
                Inventory.inventory.HealPotionImage.sprite = HealPotion5;
                Inventory.inventory.HealPotionScreenImage.sprite = HealPotion5;

            }
            if (i == 0)
            {
                Inventory.inventory.HealPotionImage.sprite = EmptyPotion;
                Inventory.inventory.HealPotionScreenImage.sprite = EmptyPotion;
                PlayerHealth.instance.maxHealth = 100;
                HeartFill.SetMaxHealth(100);
                PlayerHealth.instance.currentHealth = 100;
                Statistic.Instance.regeneration += 100;

            }

            i--;

            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(HealPotionColdown());
    }
    public IEnumerator HealPotionColdown()
    {

        {
            Inventory.inventory.HealPotionRemplissageText.SetActive(true);
            Inventory.inventory.HealPotionScreenRemplissageText.SetActive(true);

            i = HealPotionColdownTime;
            int p = i / 5;

            while (i >= 0)
            {
                if (i >= 10)
                {
                    Inventory.inventory.HealPotionTime.text = "0:" + i.ToString();
                    Inventory.inventory.HealPotionScreenTime.text = "0:" + i.ToString();
                }
                if (i < 10)
                {
                    Inventory.inventory.HealPotionTime.text = "0:0" + i.ToString();
                    Inventory.inventory.HealPotionScreenTime.text = "0:0" + i.ToString();
                }


                if (i == 0)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion5;
                    Inventory.inventory.HealPotionRemplissageText.SetActive(false);
                    Inventory.inventory.HealPotionTimeGameObject.SetActive(false);
                    Inventory.inventory.HealPotionScreenRemplissageText.SetActive(true);
                    Inventory.inventory.HealPotionScreenTimeGameObject.SetActive(false);
                    Inventory.inventory.HealPotionScreenImageGameObject.SetActive(false);
                    Inventory.inventory.HealPotionScreenRemplissageText.SetActive(false);
                    Inventory.inventory.HealPotionTime.text = "0:00";
                    HealPotionIsInUse = false;
                    i = 0;
                }
                if (i == p)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion5;
                    Inventory.inventory.HealPotionScreenImage.sprite = HealPotion5;
                }
                if (i == p + p)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion4;
                    Inventory.inventory.HealPotionScreenImage.sprite = HealPotion4;

                }
                if (i == p + p + p)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion3;
                    Inventory.inventory.HealPotionScreenImage.sprite = HealPotion3;

                }
                if (i == p + p + p + p)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion2;
                    Inventory.inventory.HealPotionScreenImage.sprite = HealPotion2;

                }
                if (i == p + p + p + p + p)
                {
                    Inventory.inventory.HealPotionImage.sprite = HealPotion1;
                    Inventory.inventory.HealPotionScreenImage.sprite = HealPotion1;

                }

                i--;
                yield return new WaitForSeconds(1f);
            }

        }
    }


    public IEnumerator SpeedPotionUsing()
    {

        i = SpeedPotionUseTime;
        int p = i / 5;

        while (i >= 0)
        {
            if (i >= 10)
            {
                Inventory.inventory.SpeedPotionTime.text = "0:" + i.ToString();
                Inventory.inventory.SpeedPotionScreenTime.text = "0:" + i.ToString();
            }
            if (i < 10)
            {
                Inventory.inventory.SpeedPotionTime.text = "0:0" + i.ToString();
                Inventory.inventory.SpeedPotionScreenTime.text = "0:0" + i.ToString();
            }


            if (i == p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion1;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion1;
            }
            if (i == p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion2;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion2;
            }
            if (i == p + p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion3;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion3;
            }
            if (i == p + p + p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion4;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion3;
            }
            if (i == p + p + p + p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion5;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion5;
            }
            if (i == 0)
            {
                Inventory.inventory.SpeedPotionImage.sprite = EmptyPotion;
                Inventory.inventory.SpeedPotionScreenImage.sprite = EmptyPotion;
                PlayerMovement.instance.moveSpeed = 150f;
                Cameranimator.SetBool("Is Speed", false);

            }

            i--;

            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(SpeedPotionColdown());
    }
    public IEnumerator SpeedPotionColdown()
    {
        Inventory.inventory.SpeedPotionRemplissageText.SetActive(true);
        Inventory.inventory.SpeedPotionScreenRemplissageText.SetActive(true);
        i = SpeedPotionColdownTime;
        int p = i / 5;

        while (i >= 0)
        {
            if (i >= 10)
            {
                Inventory.inventory.SpeedPotionTime.text = "0:" + i.ToString();
                Inventory.inventory.SpeedPotionScreenTime.text = "0:" + i.ToString();
            }
            if (i < 10)
            {
                Inventory.inventory.SpeedPotionTime.text = "0:0" + i.ToString();
                Inventory.inventory.SpeedPotionScreenTime.text = "0:0" + i.ToString();
            }


            if (i == 0)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion5;
                Inventory.inventory.SpeedPotionRemplissageText.SetActive(false);
                Inventory.inventory.SpeedPotionTimeGameObject.SetActive(false);
                Inventory.inventory.SpeedPotionScreenTimeGameObject.SetActive(false);
                Inventory.inventory.SpeedPotionScreenImageGameObject.SetActive(false);
                Inventory.inventory.SpeedPotionScreenRemplissageText.SetActive(false);
                Inventory.inventory.SpeedPotionScreen.SetActive(false);
                Inventory.inventory.SpeedPotionTime.text = "0:00";
                SpeedPotionIsInUse = false;
                i = 0;
            }
            if (i == p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion5;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion5;
            }
            if (i == p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion4;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion4;
            }
            if (i == p + p + p)
            {
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion3;
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion3;
            }
            if (i == p + p + p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion2;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion2;
            }
            if (i == p + p + p + p + p)
            {
                Inventory.inventory.SpeedPotionImage.sprite = SpeedPotion1;
                Inventory.inventory.SpeedPotionScreenImage.sprite = SpeedPotion1;
            }

            i--;
            yield return new WaitForSeconds(1f);
        }

    }

    public IEnumerator JumpPotionUsing()
    {
        i = JumpPotionUseTime;
        int p = i / 5;

        while (i >= 0)
        {
            if (i >= 10)
            {
                Inventory.inventory.JumpPotionTime.text = "0:" + i.ToString();
                Inventory.inventory.JumpPotionScreenTime.text = "0:" + i.ToString();
            }
            if (i < 10)
            {
                Inventory.inventory.JumpPotionTime.text = "0:0" + i.ToString();
                Inventory.inventory.JumpPotionScreenTime.text = "0:0" + i.ToString();
            }


            if (i == p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion1;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion1;
            }
            if (i == p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion2;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion2;

            }
            if (i == p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion3;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion3;

            }
            if (i == p + p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion4;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion4;

            }
            if (i == p + p + p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion5;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion5;

            }
            if (i == 0)
            {
                Inventory.inventory.JumpPotionImage.sprite = EmptyPotion;
                Inventory.inventory.JumpPotionScreenImage.sprite = EmptyPotion;
                PlayerMovement.instance.jumpForce = 300f;
            }

            i--;

            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(JumpPotionColdown());
    }
    public IEnumerator JumpPotionColdown()
    {
        Inventory.inventory.JumpPotionRemplissageText.SetActive(true);
        Inventory.inventory.JumpPotionScreenRemplissageText.SetActive(true);

        i = JumpPotionColdownTime;
        int p = i / 5;

        while (i >= 0)
        {
            if (i >= 10)
            {
                Inventory.inventory.JumpPotionTime.text = "0:" + i.ToString();
                Inventory.inventory.JumpPotionScreenTime.text = "0:" + i.ToString();
            }
            if (i < 10)
            {
                Inventory.inventory.JumpPotionTime.text = "0:0" + i.ToString();
                Inventory.inventory.JumpPotionScreenTime.text = "0:0" + i.ToString();
            }


            if (i == 0)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion5;
                Inventory.inventory.JumpPotionRemplissageText.SetActive(false);
                Inventory.inventory.JumpPotionTimeGameObject.SetActive(false);
                Inventory.inventory.JumpPotionScreenRemplissageText.SetActive(true);
                Inventory.inventory.JumpPotionScreenTimeGameObject.SetActive(false);
                Inventory.inventory.JumpPotionScreenImageGameObject.SetActive(false);
                Inventory.inventory.JumpPotionScreenRemplissageText.SetActive(false);
                Inventory.inventory.JumpPotionTime.text = "0:00";
                JumpPotionIsInUse = false;
                i = 0;
            }
            if (i == p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion5;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion5;
            }
            if (i == p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion4;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion4;

            }
            if (i == p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion3;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion3;

            }
            if (i == p + p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion2;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion2;

            }
            if (i == p + p + p + p + p)
            {
                Inventory.inventory.JumpPotionImage.sprite = JumpPotion1;
                Inventory.inventory.JumpPotionScreenImage.sprite = JumpPotion1;

            }

            i--;
            yield return new WaitForSeconds(1f);
        }

    }
}

