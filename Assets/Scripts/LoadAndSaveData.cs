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
        if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health") > 100)
        {
            PlayerHealth.instance.currentHealth = 100;
            PlayerHealth.instance.healthBar.SetHealth(100);
        }

        if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health") <= 100)
        {
            PlayerHealth.instance.currentHealth = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health");
            PlayerHealth.instance.healthBar.SetHealth(PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Health"));
        }
        
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


    public void SaveStatistics()
    {
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:dead", Statistic.Instance.dead);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:damage", Statistic.Instance.damage);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:regeneration", Statistic.Instance.regeneration);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:speedPotionUse", Statistic.Instance.speedPotionUse);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:healPotionUse", Statistic.Instance.healPotionUse);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumpPotionUse", Statistic.Instance.jumpPotionUse);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:speedPotionCollected", Statistic.Instance.speedPotionCollected);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:healPotionCollected", Statistic.Instance.healPotionCollected);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumpPotionCollected", Statistic.Instance.jumpPotionCollected);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumps", Statistic.Instance.jumps);
        PlayerPrefs.SetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:distanceTraveled", Statistic.Instance.distanceTraveled);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:collectedCoins", Statistic.Instance.collectedCoins);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeS", Statistic.Instance.timeS);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeM", Statistic.Instance.timeM);
        PlayerPrefs.SetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeH", Statistic.Instance.timeH);
        
    }
    
    public void LoadStatistics()
    {
        Statistic.Instance.dead = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:dead", Statistic.Instance.dead);
        Statistic.Instance.damage = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:damage", Statistic.Instance.damage);
        Statistic.Instance.regeneration = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:regeneration", Statistic.Instance.regeneration);
        Statistic.Instance.speedPotionUse = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:speedPotionUse", Statistic.Instance.speedPotionUse);
        Statistic.Instance.healPotionUse = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:healPotionUse", Statistic.Instance.healPotionUse);
        Statistic.Instance.jumpPotionUse = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumpPotionUse", Statistic.Instance.jumpPotionUse);
        Statistic.Instance.speedPotionCollected = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:speedPotionCollected", Statistic.Instance.speedPotionCollected);
        Statistic.Instance.healPotionCollected = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:healPotionCollected", Statistic.Instance.healPotionCollected);
        Statistic.Instance.jumpPotionCollected = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumpPotionCollected", Statistic.Instance.jumpPotionCollected);
        Statistic.Instance.jumps = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:jumps", Statistic.Instance.jumps);
        Statistic.Instance.distanceTraveled = PlayerPrefs.GetFloat("Player" + CharacterManager.instance.CurrentCharacter + "STAT:distanceTraveled", Statistic.Instance.distanceTraveled) + PlayerMovement.instance.Player.transform.position.x;
        Statistic.Instance.collectedCoins = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:collectedCoins", Statistic.Instance.collectedCoins);
        Statistic.Instance.timeS = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeS", Statistic.Instance.timeS);
        Statistic.Instance.timeM = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeM", Statistic.Instance.timeM);
        Statistic.Instance.timeH = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "STAT:timeH", Statistic.Instance.timeH);
        
    }
}
