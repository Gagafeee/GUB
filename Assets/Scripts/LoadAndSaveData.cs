using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    public CointInventory cointInventory;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
            if (ErrorManager.instance.developperMode == true)
            {
                MyNotifications.CallNotification("Sauvegarder!", 2f);
            }

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (ErrorManager.instance.developperMode == true)
            {
                MyNotifications.CallNotification("Loading...", 1.7f);
            }
            LoadData();

            if (ErrorManager.instance.developperMode == true)
            {
                MyNotifications.CallNotification("Loaded", 2f);
            }

        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de LoadAndSaveData dans la scène");
            return;
        }

        instance = this;
    }
    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        CointInventory.instance.coinsCount = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Coints");
        PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health");
        PlayerHealth.instance.healthBar.SetHealth(PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health"));
        Inventory.inventory.SpeedPotionValue = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "SpeedPotion");
        Inventory.inventory.HealPotionValue = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "HealPotion");
        Inventory.inventory.JumpPotionValue = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "JumpPotion");
        Levelmanager.instance.lastLevelUnloked = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "lastlevelunloked");
        if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "CheckpointIndex") == 1)
        {
            CurrentSceneManager.instance.isTheFirstEnterInLevel = true;
        }
        if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "CheckpointIndex") == 0)
        {
            CurrentSceneManager.instance.isTheFirstEnterInLevel = false;
            var Position = new Vector3();
            Position.x = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointX");
            Position.y = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointY");
            Position.z = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointZ");
            CurrentSceneManager.instance.SetRespawnPoint(Position);
        }

        
        
        
        PlayerMovement.instance.PositionPlayer();
        
    }



    public void SaveData()
    {
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "Coints", CointInventory.instance.coinsCount);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health", PlayerHealth.instance.currentHealth);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "SpeedPotion", Inventory.inventory.SpeedPotionValue);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "HealPotion", Inventory.inventory.HealPotionValue);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "JumpPotion", Inventory.inventory.JumpPotionValue);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "lastlevelunloked", Levelmanager.instance.actualLevel);
        if (CurrentSceneManager.instance.isTheFirstEnterInLevel == true)
        {
            PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "CheckpointIndex", 1);
        }
        if (CurrentSceneManager.instance.isTheFirstEnterInLevel == false)
        {
            PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "CheckpointIndex", 0);
        }
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointX", CurrentSceneManager.instance.RespawnPoint.x);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointY", CurrentSceneManager.instance.RespawnPoint.y);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "RespawnPointZ", CurrentSceneManager.instance.RespawnPoint.z);
        

        Debug.Log("Sucifull Saved");
    }
}
