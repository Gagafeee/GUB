using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Security.Principal; 


public class CharacterManager : MonoBehaviour
{



    public static CharacterManager instance;
    public string saveSeparator = "%";
    public int CharacterNumber;
    public int CurrentCharacter;
    public GameObject PlayerSelect;
    public Animator PlayerSelectGameUiAnimator;
    public AudioManager AudioManager;
    public AudioClip sound;
    public int TimetoSave = 3;
    public Animator musicAnim;
    public Animator videoAnim;
    public GameObject Fade;
    public float waitTime;
    [Space(15)]
    public GameObject InputFieldText;
    public GameObject InputFieldGam;
    public string TempCharacterName;
    public int TempCharacterNumber;
    public bool NewPlayerPanelIsActive;
    public Button NewPlayerPanelButton;
    public Text NewPlayerPanelErrorText;
    public GameObject NewPlayerPanelErrorTextGameObject;
    [Space(15)]
    public Toggle Didacticiel;
    [Space(30)]
    public GameObject Player0UI;
    public Text Player0Text;
    public Text Player0CointValue;
    public Text Player0Level;
    [Space(20)]
    public GameObject Player1UI;
    public Text Player1Text;
    public string Player1String = "PLAYERNAME";
    public Text Player1CointValue;
    public Text Player1Level;
    [Space(20)]
    public GameObject Player2UI;
    public Text Player2Text;
    public string Player2String = "PLAYERNAME";
    public Text Player2CointValue;
    public Text Player2Level;
    [Space(20)]
    public GameObject Player3UI;
    public Text Player3Text;
    public string Player3String = "PLAYERNAME";
    public Text Player3CointValue;
    public Text Player3Level;
    [Space(20)]
    public GameObject Player4UI;
    public Text Player4Text;
    public string Player4String = "PLAYERNAME";
    public Text Player4CointValue;
    public Text Player4Level;
    [Space(20)]
    public GameObject Player5UI;
    public Text Player5Text;
    public string Player5String = "PLAYERNAME";
    public Text Player5CointValue;
    public Text Player5Level;
    [Space(20)]
    public GameObject Player6UI;
    public Text Player6Text;
    public string Player6String = "PLAYERNAME";
    public Text Player6CointValue;
    public Text Player6Level;
    [Space(20)]
    public GameObject Player7UI;
    public Text Player7Text;
    public string Player7String = "PLAYERNAME";
    public Text Player7CointValue;
    public Text Player7Level;
    [Space(20)]
    public GameObject Player8UI;
    public Text Player8Text;
    public string Player8String = "PLAYERNAME";
    public Text Player8CointValue;
    public Text Player8Level;
    [Space(20)]
    public GameObject Player9UI;
    public Text Player9Text;
    public string Player9String = "PLAYERNAME";
    public Text Player9CointValue;
    public Text Player9Level;
    
    public void Update()
    {
        if (PlayerSelect.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePlayerSelectPanel();
            }
        }
        
        
        if (NewPlayerPanelIsActive)
        {
            string Tempvalue = InputFieldText.GetComponent<Text>().text;

            if (Tempvalue == "")
            {
                NewPlayerPanelButton.interactable = false;
            }
            else if (Tempvalue != "")
            {
                NewPlayerPanelButton.interactable = true;
            }
            
            if (Tempvalue.Contains("~") || Tempvalue.Contains("!") || Tempvalue.Contains("/") ||
                Tempvalue.Contains(";") || Tempvalue.Contains(",") || Tempvalue.Contains("^") ||
                Tempvalue.Contains("¨") || Tempvalue.Contains("*") || Tempvalue.Contains("$") ||
                Tempvalue.Contains("£") || Tempvalue.Contains("¤") || Tempvalue.Contains("%") ||
                Tempvalue.Contains("§") || Tempvalue.Contains("²") || Tempvalue.Contains("?") ||
                Tempvalue.Contains(".") || Tempvalue.Contains("`") || Tempvalue.Contains("'") ||
                Tempvalue.Contains("#") || Tempvalue.Contains("&") || Tempvalue.Contains("@"))
            {
                NewPlayerPanelButton.interactable = false;
                NewPlayerPanelErrorText.text = "Erreur : Ne pas mettre de caractères spéciaux";
                NewPlayerPanelErrorTextGameObject.SetActive(true);
            }
            else
            {
                NewPlayerPanelButton.interactable = true;
                NewPlayerPanelErrorText.text = "Error : {IUnspecified(Error)}";
                NewPlayerPanelErrorTextGameObject.SetActive(false);
            }

          

        }
    }

    public void Awake()
    {
        instance = this;

    }
    

    public void Character0creator()
    {
        TempCharacterNumber = 0;
        TempCharacterName = "Partie0";
        Didacticiel.isOn = true;
        PlayerCreator();
    }



    public void LoadCharacter()
    {
        
        PlayerSelect.SetActive(true);
        Debug.Log("Active");
        PlayerSelectGameUiAnimator.SetBool("IsOpen", true);
        Debug.Log("Trigger");
        AudioManager.PlayClipAt(sound, transform.position);
        Debug.Log("Sound");
        if (PlayerPrefs.HasKey("Player0"))
        {
            Player0Text.text = PlayerPrefs.GetString("Player0");
            Player0UI.SetActive(true);
            Player0CointValue.text = PlayerPrefs.GetInt("Player0" + "Coints").ToString();
            Player0Level.text = PlayerPrefs.GetInt("Player0"  + "lastlevelunloked").ToString();
            CharacterNumber++;
            Debug.Log("load player 0");
        }
        else
        {
            Player0UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player1"))
        {
            Player1String = PlayerPrefs.GetString("Player1");
            Player1Text.text = PlayerPrefs.GetString("Player1");
            Player1CointValue.text = PlayerPrefs.GetInt("Player1" + "Coints").ToString();
            Player1Level.text = PlayerPrefs.GetInt("Player1"  + "lastlevelunloked").ToString();
            
            Player1UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 1");
        }
        else
        {
            Player1UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player2"))
        {
            Player2String = PlayerPrefs.GetString("Player2");
            Player2Text.text = PlayerPrefs.GetString("Player2");
            Player2CointValue.text = PlayerPrefs.GetInt("Player2" + "Coints").ToString();
            Player2Level.text = PlayerPrefs.GetInt("Player2"  + "lastlevelunloked").ToString();
            Player2UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 2");
        }
        else
        {
            Player2UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player3"))
        {
            Player3String = PlayerPrefs.GetString("Player3");
            Player3Text.text = PlayerPrefs.GetString("Player3");
            Player3CointValue.text = PlayerPrefs.GetInt("Player3" + "Coints").ToString();
            Player3Level.text = PlayerPrefs.GetInt("Player3"  + "lastlevelunloked").ToString();
            Player3UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 3");

        }
        else
        {
            Player3UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player4"))
        {
            Player4String = PlayerPrefs.GetString("Player4");
            Player4Text.text = PlayerPrefs.GetString("Player4");
            Player4CointValue.text = PlayerPrefs.GetInt("Player4" + "Coints").ToString();
            Player4Level.text = PlayerPrefs.GetInt("Player4"  + "lastlevelunloked").ToString();
            Player4UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 4");
        }
        else
        {
            Player4UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player5"))
        {
            Player5String = PlayerPrefs.GetString("Player5");
            Player5Text.text = PlayerPrefs.GetString("Player5");
            Player5CointValue.text = PlayerPrefs.GetInt("PlayerX" + "Coints").ToString();
            Player5Level.text = PlayerPrefs.GetInt("PlayerX"  + "lastlevelunloked").ToString();
            Player5UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 5");
        }
        else
        {
            Player5UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player6"))
        {
            Player6String = PlayerPrefs.GetString("Player6");
            Player6Text.text = PlayerPrefs.GetString("Player6");
            Player6CointValue.text = PlayerPrefs.GetInt("Player6" + "Coints").ToString();
            Player6Level.text = PlayerPrefs.GetInt("Player6"  + "lastlevelunloked").ToString();
            Player6UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 6");

        }
        else
        {
            Player6UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player7"))
        {
            Player7String = PlayerPrefs.GetString("Player7");
            Player7Text.text = PlayerPrefs.GetString("Player7");
            Player7CointValue.text = PlayerPrefs.GetInt("Player7" + "Coints").ToString();
            Player7Level.text = PlayerPrefs.GetInt("Player7"  + "lastlevelunloked").ToString();
            Player7UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 7");
        }
        else
        {
            Player7UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player8"))
        {
            Player8String = PlayerPrefs.GetString("Player8");
            Player8Text.text =PlayerPrefs.GetString("Player8");
            Player8CointValue.text = PlayerPrefs.GetInt("Player8" + "Coints").ToString();
            Player8Level.text = PlayerPrefs.GetInt("Player8"  + "lastlevelunloked").ToString();
            Player8UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 8");
        }
        else
        {
            Player8UI.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Player9"))
        {
            Player9String = PlayerPrefs.GetString("Player9");
            Player9Text.text = PlayerPrefs.GetString("Player9");
            Player9CointValue.text = PlayerPrefs.GetInt("Player9" + "Coints").ToString();
            Player9Level.text = PlayerPrefs.GetInt("Player9"  + "lastlevelunloked").ToString();
            Player9UI.SetActive(true);
            CharacterNumber++;
            Debug.Log("load player 9");

        }
        else
        {
            Player9UI.SetActive(false);
        }

    }

    public void ClosePlayerSelectPanel()
    {
        StartCoroutine(ClosePlayerSelectPanelCOR());
    }
    public IEnumerator ClosePlayerSelectPanelCOR()
    {
        AudioManager.PlayClipAt(sound, transform.position);
        PlayerSelectGameUiAnimator.SetBool("IsOpen", false);
        yield return new WaitForSeconds(1f);
        PlayerSelect.SetActive(false);
        }
    public void NewPlayer1()
    {
        InputFieldGam.SetActive(true);
        NewPlayerPanelIsActive = true;
        TempCharacterNumber = 1;

    }
    public void NewPlayer2()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 2;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer3()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 3;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer4()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 4;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer5()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 5;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer6()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 6;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer7()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 7;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer8()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 8;
        NewPlayerPanelIsActive = true;

    }
    public void NewPlayer9()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 9;
        NewPlayerPanelIsActive = true;

    }
    public void closeNewPlayerPanel()
    {
        InputFieldGam.SetActive(false);
        PlayerPrefs.DeleteKey("Player" + TempCharacterNumber + "Didacticiel");
        TempCharacterNumber = 0;
        AudioManager.PlayClipAt(sound, transform.position);
        NewPlayerPanelIsActive = false;
    }
    public void CharacterNameRecuperator()
    {
        TempCharacterName = InputFieldText.GetComponent<Text>().text;
        PlayerCreator();

    }

    private void PlayerCreator()
    {
        PlayerPrefs.SetString("Player" + TempCharacterNumber, TempCharacterName);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Coints", 0);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "SpeedPotion", 0);
       // PlayerPrefs.SetInt("Player" + TempCharacterNumber + "BigSpeedPotion", 0);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "HealPotion", 0);
       // PlayerPrefs.SetInt("Player" + TempCharacterNumber + "BigHealPotion", 0);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "JumpPotion", 0);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Health", 100);
        
        PlayerPrefs.SetFloat("Player" + TempCharacterNumber + "StartPosX", -46);
        PlayerPrefs.SetFloat("Player" + TempCharacterNumber + "StartPosY", 3);
        PlayerPrefs.SetFloat("Player" + TempCharacterNumber + "StartPosZ", 0);
        PlayerPrefs.SetInt("Player" + TempCharacterNumber + "CheckpointIndex", 1);
        
        if (Didacticiel.isOn)
        {
            PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Didacticiel", 1);
        }
        if (Didacticiel.isOn == false)
        {
            PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Didacticiel", 0);
        }
        
        LoadCharacter();
        InputFieldGam.SetActive(false);
        TempCharacterNumber = 0;
        TempCharacterName = "none";

    }
    


    public void DeletePlayer0(bool notif)
    {
        switch (notif)
        {
            case true:
                MyNotifications.CallNotification("Partie Supprimée",2);
                break;
            case false:
                break;
        }
        
        DeletePlayer(0);
        Character0creator();
        

    }
    
    public void DeletePlayer1()
    {
        DeletePlayer(1);

    }
    public void DeletePlayer2()
    {
        DeletePlayer(2);

    }
    public void DeletePlayer3()
    {
        DeletePlayer(3);

    }
    public void DeletePlayer4()
    {
        DeletePlayer(4);
    }
    public void DeletePlayer5()
    {
        DeletePlayer(5);
    }
    public void DeletePlayer6()
    {
        DeletePlayer(6);

    }
    public void DeletePlayer7()
    {
        DeletePlayer(7);
    }
    public void DeletePlayer8()
    {
        DeletePlayer(8);
    }

    public void DeletePlayer9()
    {
        DeletePlayer(9);
    }

    private void DeletePlayer(int characterId)
    {
        PlayerPrefs.DeleteKey("Player" + characterId);
        PlayerPrefs.DeleteKey("Player" + characterId + "Coints");
        PlayerPrefs.DeleteKey("Player" + characterId + "SpeedPotion");
        PlayerPrefs.DeleteKey("Player" + characterId + "BigSpeedPotion");
        PlayerPrefs.DeleteKey("Player" + characterId + "HealPotion");
        PlayerPrefs.DeleteKey("Player" + characterId + "BigHealPotion");
        PlayerPrefs.DeleteKey("Player" + characterId + "Health");
        PlayerPrefs.DeleteKey("Player" + characterId + "JumpPotion");
        PlayerPrefs.DeleteKey("Player" + characterId + "StartPosX");
        PlayerPrefs.DeleteKey("Player" + characterId + "StartPosY");
        PlayerPrefs.DeleteKey("Player" + characterId + "StartPosZ");
        PlayerPrefs.DeleteKey("Player" + characterId + "lastlevelunloked");
        PlayerPrefs.DeleteKey("Player" + characterId + "RespawnPointX");
        PlayerPrefs.DeleteKey("Player" + characterId + "RespawnPointY");
        PlayerPrefs.DeleteKey("Player" + characterId + "RespawnPointZ");
        PlayerPrefs.DeleteKey("Player" + characterId + "CheckpointIndex");
        PlayerPrefs.DeleteKey("Player" + characterId + "Didacticiel");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:dead");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:damage");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:regeneration");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:speedPotionUse");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:healPotionUse");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:jumpPotionUse");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:speedPotionCollected");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:healPotionCollected");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:jumpPotionCollected");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:jumps");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:distanceTraveled");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:collectedCoins");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:timeS");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:timeM");
        PlayerPrefs.DeleteKey("Player" + characterId + "STAT:timeH");

        LoadCharacter();
        AudioManager.PlayClipAt(sound, transform.position);
    }

    

    public void play0()
    {
        loadPlayer(0);
    }
    public void play1()

    {
        loadPlayer(1);
    }
    public void play2()
    {
        loadPlayer(2);
    }
    public void play3()
    {
        loadPlayer(3);
    }
    public void play4()
    {
        loadPlayer(4);
    }
    public void play5()
    {
        loadPlayer(5);
    }
    public void play6()
    {
        loadPlayer(6);
    }
    public void play7()
    {
        loadPlayer(7);
    }
    public void play8()
    {
        loadPlayer(8);
    }
    public void play9()
    {
        loadPlayer(9);
    }



    public void loadPlayer(int playerNumber)
    {
        AudioManager.PlayClipAt(sound, transform.position);
        CurrentCharacter = playerNumber;
        StartCoroutine(ChangeScene());

        Debug.Log("Sucifull loaded");
    }

    IEnumerator ChangeScene()
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        musicAnim.SetTrigger("Transition");
        videoAnim.SetTrigger("TR");
        yield return new WaitForSeconds(waitTime);
      Levelmanager.instance.lastLevelUnloked = PlayerPrefs.GetInt("Player" + CurrentCharacter + "lastlevelunloked");  
        //if is the first time to load this player
      if (Levelmanager.instance.lastLevelUnloked == 0)
      {
          //if didacticiel is active
         
          if (PlayerPrefs.GetInt("Player" + CurrentCharacter + "Didacticiel") == 1)
          {
             Levelmanager.instance.lastLevelUnloked = 1; 
          }
          if (PlayerPrefs.GetInt("Player" + CurrentCharacter + "Didacticiel") == 0)
          {
              Levelmanager.instance.lastLevelUnloked = 2; 
          }
          
      }
      
      SceneManager.LoadSceneAsync("Level" + Levelmanager.instance.lastLevelUnloked);
      
 
       

        
    }

}
