using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;
    public Statistic statistic;
    public int ___________________________________________;
    public GameObject Panel;
    public Animator animator;
    public bool InventoryIsOpen = false;
    public GameObject ScreenPanel;
    public Animator ScreenInventory;

    public int ______________________________________________;

    public Text CointQTText;
    public Image CointImage;

    public int _________________________________________;
    public Text ItemQTText;
    public Image ItemImage;
    public int ItemValue;
    public int ________________________________________;
    public Text SpeedPotionQTText;
    public Image SpeedPotionImage;
    public int SpeedPotionValue;
    public GameObject SpeedPotionUseButton;
    public Text SpeedPotionTime;
    public GameObject SpeedPotionTimeGameObject;
    public GameObject SpeedPotionRemplissageText;
    public Text SpeedPotionNameText;
    public Text SpeedPotionScreenTime;
    public Image SpeedPotionScreenImage;
    public GameObject SpeedPotionScreenTimeGameObject;
    public GameObject SpeedPotionScreenImageGameObject;
    public GameObject SpeedPotionScreenRemplissageText;
    public GameObject SpeedPotionScreen;
    public int _______________________________________;
    public Text HealPotionQTText;
    public Image HealPotionImage;
    public int HealPotionValue;
    public GameObject HealPotionUseButton;
    public Text HealPotionTime;
    public GameObject HealPotionTimeGameObject;
    public GameObject HealPotionRemplissageText;
    public Text HealPotionNameText;
    public Text HealPotionScreenTime;
    public Image HealPotionScreenImage;
    public GameObject HealPotionScreenTimeGameObject;
    public GameObject HealPotionScreenImageGameObject;
    public GameObject HealPotionScreenRemplissageText;
    public GameObject HealPotionScreen;
    public int ______________________________________;
    public Text JumpPotionQTText;
    public Image JumpPotionImage;
    public int JumpPotionValue;
    public GameObject JumpPotionUseButton;
    public Text JumpPotionTime;
    public GameObject JumpPotionTimeGameObject;
    public GameObject JumpPotionRemplissageText;
    public Text JumpPotionNameText;
    public Text JumpPotionScreenTime;
    public Image JumpPotionScreenImage;
    public GameObject JumpPotionScreenTimeGameObject;
    public GameObject JumpPotionScreenImageGameObject;
    public GameObject JumpPotionScreenRemplissageText;
    public GameObject JumpPotionScreen;


    public void Start()
    {
        CloseInventory();
    }
    public void Awake()
    {
        if (inventory != null)
        {
            Debug.LogWarning("Attention il ya plus d'une instance de inventory dans la scene ! ");
        }

        inventory = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InventoryIsOpen == false)
        {
            OpenInventory();
        }
        else if (Input.GetKeyDown(KeyCode.E) && InventoryIsOpen == true)
        {
            CloseInventory();
        }

        
        RefreshInventory();
    }
    public void OpenInventory()
    {
        animator.SetBool("Is Open", true);
        InventoryIsOpen = true;
    }


    public void CloseInventory()
    {
        animator.SetBool("Is Open", false);
        InventoryIsOpen = false;
    }


    public void RefreshInventory()
    {
        CointInventory.instance.coinsCountText.text = CointInventory.instance.coinsCount.ToString();
        ItemQTText.text = ItemValue.ToString();
        SpeedPotionQTText.text = SpeedPotionValue.ToString();
        HealPotionQTText.text = HealPotionValue.ToString();
        JumpPotionQTText.text = JumpPotionValue.ToString();
        //coint
        if (CointInventory.instance.coinsCount <= 0)
        {
            CointImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 70);
        }
        if (CointInventory.instance.coinsCount > 0)
        {
            CointImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);

        }

        //items
        if (ItemValue <= 0)
        {
            ItemImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);
        }
        if (ItemValue > 0)
        {
            ItemImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
        }

        //speed
        if (SpeedPotionValue <= 0 && PotionManager.Instance.SpeedPotionIsInUse == false)
        {
            SpeedPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);
            SpeedPotionNameText.text = " ";
        }

        if (PotionManager.Instance.SpeedPotionIsInUse == true)
        {
            SpeedPotionUseButton.SetActive(false);
        }

        if (SpeedPotionValue > 0 && PotionManager.Instance.SpeedPotionIsInUse == false)
        {
            SpeedPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            SpeedPotionUseButton.SetActive(true);
            SpeedPotionTimeGameObject.SetActive(true);
            SpeedPotionNameText.text = "Potion de Vitesse";
        }


        //heal
        if (HealPotionValue <= 0 && PotionManager.Instance.HealPotionIsInUse == false)
        {
            HealPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);
            HealPotionNameText.text = " ";
        }

        if (PotionManager.Instance.HealPotionIsInUse == true)
        {
            HealPotionUseButton.SetActive(false);
        }

        if (HealPotionValue > 0 && PotionManager.Instance.HealPotionIsInUse == false)
        {
            HealPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            HealPotionUseButton.SetActive(true);
            HealPotionTimeGameObject.SetActive(true);
            HealPotionNameText.text = "Potion de Vie";
        }

        //jump

        if (JumpPotionValue <= 0 && PotionManager.Instance.JumpPotionIsInUse == false)
        {
            JumpPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 0);
            JumpPotionNameText.text = " ";
        }

        if (PotionManager.Instance.JumpPotionIsInUse == true)
        {
            JumpPotionUseButton.SetActive(false);
        }

        if (JumpPotionValue > 0 && PotionManager.Instance.JumpPotionIsInUse == false)
        {
            JumpPotionImage.GetComponent<Image>().color = Color.HSVToRGB(0, 0, 100);
            JumpPotionUseButton.SetActive(true);
            JumpPotionTimeGameObject.SetActive(true);
            JumpPotionNameText.text = "Potion de Saut";
        }



        if (SpeedPotionValue <= -1)
        {
            SpeedPotionValue = 0;
            ErrorManager.instance.FataleError("Vous avez utilier un objet que vous n'avier pas." +
                " Inventory.instance.SpeedPotionValue[BASE].FatalError", "Solved (Restart your game)");
        }
        if (HealPotionValue <= -1)
        {
            HealPotionValue = 0;
            ErrorManager.instance.FataleError("Vous avez utilier un objet que vous n'avier pas." +
                " Inventory.instance.HealPotionValue[BASE].FatalError", "Solved (Restart your game)");
        }
        if (JumpPotionValue <= -1)
        {
            JumpPotionValue = 0;
            ErrorManager.instance.FataleError("Vous avez utilier un objet que vous n'avier pas." +
                " Inventory.instance.JumpPotionValue[BASE].FatalError", "Solved (Restart your game)");

        }


        //speedAnimation

        if (PotionManager.Instance.SpeedPotionIsInUse == true || PotionManager.Instance.HealPotionIsInUse == true || PotionManager.Instance.JumpPotionIsInUse == true)
        {
            ScreenInventory.SetBool("Screen Is Open", true);
        }
        if (PotionManager.Instance.SpeedPotionIsInUse == false && PotionManager.Instance.HealPotionIsInUse == false && PotionManager.Instance.JumpPotionIsInUse == false)
        {
            ScreenInventory.SetBool("Screen Is Open", false);
        }


    }
    
    /*
     * 0 = yellow roche
     *1 = speed potion
     *2 = heal potion
     *3 = jump potion
     * 
     */
    

    public void AddItems(int itemType, int amount)
    {
        if (itemType == 0)
        {
           statistic.AddItems(0,amount);
        }
        if (itemType == 1)
        {
            statistic.AddItems(1,amount);
        }
        if (itemType == 2)
        {
            statistic.AddItems(2,amount);
        }
        if (itemType == 3)
        {
            statistic.AddItems(3,amount);
        }
    }


    public void AddItems()
    {
        throw new System.NotImplementedException();
    }
}
