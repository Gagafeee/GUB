using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{

    private Text interactUI;
    private bool IsinRange;
    public GameObject ChestItems;

    public Animator chestanimator;
    public Animator ItemsAnimator;
    public int NumberOfItemsToAdd;
    public AudioClip sound;
    public static Chest instance;
    public int ItemType;

    public SpriteRenderer ChestItemSpriteRenderer;
    public Sprite ItemRenderer;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    public void Start()
    {
        ChestItemSpriteRenderer.sprite = ItemRenderer;
        ChestItems.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z) && IsinRange)
        {
            OpenChest();
        }


    }

    private void OpenChest()
    {
        chestanimator.SetTrigger("OpenChest");
        ChestItems.SetActive(true);
        ItemsAnimator.SetTrigger("Spawn");
        AudioManager.instance.PlayClipAt(sound, transform.position);
        if (ItemType == 0)
        {
            CointInventory.instance.AddCoins(NumberOfItemsToAdd);
        }
        if (ItemType == 1)
        {
            Inventory.inventory.AddItems(1, NumberOfItemsToAdd);
        }
        if (ItemType == 2)
        {
            Inventory.inventory.AddItems(2, NumberOfItemsToAdd);
        }

        if (ItemType == 3)
        {
            Inventory.inventory.AddItems(3, NumberOfItemsToAdd);
        }
        LoadAndSaveData.instance.SaveData();
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            IsinRange = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            IsinRange = false;
        }

    }
}

