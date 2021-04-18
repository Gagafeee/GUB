using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public GameObject InputFieldText;
    public GameObject InputFieldGam;
    public string TempCharacterName;
    public int TempCharacterNumber;
    public bool NewPlayerPanelIsAtive;
    public Button NewPlayerPanelButton;
    public Text NewPlayerPanelErrorText;
    public GameObject NewPlayerPanelErrorTextGameObject;


    public Toggle Didacticiel;

    public GameObject Player0UI;
    public Text Player0Text;


    public GameObject Player1UI;
    public Text Player1Text;
    public string Player1String = "NONE";

    public GameObject Player2UI;
    public Text Player2Text;
    public string Player2String = "NONE";

    public GameObject Player3UI;
    public Text Player3Text;
    public string Player3String = "NONE";

    public GameObject Player4UI;
    public Text Player4Text;
    public string Player4String = "NONE";

    public GameObject Player5UI;
    public Text Player5Text;
    public string Player5String = "NONE";

    public GameObject Player6UI;
    public Text Player6Text;
    public string Player6String = "NONE";

    public GameObject Player7UI;
    public Text Player7Text;
    public string Player7String = "NONE";

    public GameObject Player8UI;
    public Text Player8Text;
    public string Player8String = "NONE";

    public GameObject Player9UI;
    public Text Player9Text;
    public string Player9String = "NONE";




    public void Update()
    {
        if (PlayerSelect.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePlayerSelectPanel();
            }
        }
        
        
        if (NewPlayerPanelIsAtive == true)
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
                Tempvalue.Contains("#") || Tempvalue.Contains("&") || Tempvalue.Contains("@") ||
                Tempvalue.Contains(" "))
            {
                NewPlayerPanelButton.interactable = false;
                NewPlayerPanelErrorText.text = "Erreur : Ne pas mettre de caractères spéciaux Ni d'espace";
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
        PlayerCreator();
    }



    public void LoadCharacter()
    {
        
        PlayerSelect.SetActive(true);
        PlayerSelectGameUiAnimator.SetBool("IsOpen", true);
        AudioManager.PlayClipAt(sound, transform.position);
        if (File.Exists(Application.dataPath + "/Data/players/Player0.txt"))
        {
            string SavePlayer0 = File.ReadAllText(Application.dataPath + "/Data/players/Player0.txt");

            Player0Text.text = SavePlayer0;
            Player0UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 0");
        }
        else
        {
            Player0UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player1.txt"))
        {
            string SavePlayer1 = File.ReadAllText(Application.dataPath + "/Data/players/Player1.txt");

            Player1String = SavePlayer1;
            Player1Text.text = SavePlayer1;
            Player1UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 1");
        }
        else
        {
            Player1UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player2.txt"))
        {
            string SavePlayer2 = File.ReadAllText(Application.dataPath + "/Data/players/Player2.txt");

            Player2String = SavePlayer2;
            Player2Text.text = SavePlayer2;
            Player2UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 2");
        }
        else
        {
            Player2UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player3.txt"))
        {
            string SavePlayer3 = File.ReadAllText(Application.dataPath + "/Data/players/Player3.txt");

            Player3String = SavePlayer3;
            Player3Text.text = SavePlayer3;
            Player3UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 3");

        }
        else
        {
            Player3UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player4.txt"))
        {
            string SavePlayer4 = File.ReadAllText(Application.dataPath + "/Data/players/Player4.txt");

            Player4String = SavePlayer4;
            Player4Text.text = SavePlayer4;
            Player4UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 4");
        }
        else
        {
            Player4UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player5.txt"))
        {
            string SavePlayer5 = File.ReadAllText(Application.dataPath + "/Data/players/Player5.txt");

            Player5String = SavePlayer5;
            Player5Text.text = SavePlayer5;
            Player5UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 5");
        }
        else
        {
            Player5UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player6.txt"))
        {
            string SavePlayer6 = File.ReadAllText(Application.dataPath + "/Data/players/Player6.txt");

            Player6String = SavePlayer6;
            Player6Text.text = SavePlayer6;
            Player6UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 6");

        }
        else
        {
            Player6UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player7.txt"))
        {
            string SavePlayer7 = File.ReadAllText(Application.dataPath + "/Data/players/Player7.txt");

            Player7String = SavePlayer7;
            Player7Text.text = SavePlayer7;
            Player7UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 7");
        }
        else
        {
            Player7UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player8.txt"))
        {
            string SavePlayer8 = File.ReadAllText(Application.dataPath + "/Data/players/Player8.txt");

            Player8String = SavePlayer8;
            Player8Text.text = SavePlayer8;
            Player8UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 8");
        }
        else
        {
            Player8UI.SetActive(false);
        }
        if (File.Exists(Application.dataPath + "/Data/players/Player9.txt"))
        {
            string SavePlayer9 = File.ReadAllText(Application.dataPath + "/Data/players/Player9.txt");

            Player9String = SavePlayer9;
            Player9Text.text = SavePlayer9;
            Player9UI.SetActive(true);
            CharacterNumber++;
            // Debug.Log("load player 9");

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
        NewPlayerPanelIsAtive = true;
        TempCharacterNumber = 1;

    }
    public void NewPlayer2()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 2;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer3()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 3;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer4()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 4;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer5()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 5;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer6()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 6;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer7()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 7;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer8()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 8;
        NewPlayerPanelIsAtive = true;

    }
    public void NewPlayer9()
    {
        InputFieldGam.SetActive(true);
        TempCharacterNumber = 9;
        NewPlayerPanelIsAtive = true;

    }
    public void closeNewPlayerPanel()
    {
        InputFieldGam.SetActive(false);
        PlayerPrefs.DeleteKey("Player" + TempCharacterNumber + "Didacticiel");
        TempCharacterNumber = 0;
        AudioManager.PlayClipAt(sound, transform.position);
        NewPlayerPanelIsAtive = false;
    }
    public void CharacterNameRecuperator()
    {
        TempCharacterName = InputFieldText.GetComponent<Text>().text;
        PlayerCreator();

    }

    private void PlayerCreator()
    {
        File.WriteAllText(Application.dataPath + "/Data/players/Player" + TempCharacterNumber + ".txt", TempCharacterName);
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
        
        setDidacticiel(Didacticiel.isOn); 
        
        LoadCharacter();
        InputFieldGam.SetActive(false);
        TempCharacterNumber = 0;
        TempCharacterName = "none";

    }

    public void setDidacticiel(bool isactive)
    {
        
        if (isactive)
        {
            PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Didacticiel", 1);
        }
        if (isactive == false)
        {
            PlayerPrefs.SetInt("Player" + TempCharacterNumber + "Didacticiel", 0);
        }
        
    }


    public void DeletePlayer0()
    {
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

    public void DeletePlayer(int CharacterId)
    {
        File.Delete(Application.dataPath + "/Data/players/Player" + CharacterId + ".txt");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "Coints");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "SpeedPotion");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "BigSpeedPotion");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "HealPotion");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "BigHealPotion");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "Health");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "JumpPotion");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "StartPosX");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "StartPosY");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "StartPosZ");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "lastlevelunloked");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "RespawnPointX");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "RespawnPointY");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "RespawnPointZ");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "CheckpointIndex");
        PlayerPrefs.DeleteKey("Player" + CharacterId + "Didacticiel");
        
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
      Levelmanager.instance.lastLevelUnloked = PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "lastlevelunloked");  
        //if is the first time to load this player
      if (Levelmanager.instance.lastLevelUnloked == 0)
      {
          //if didacticiel is active
         
          if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Didacticiel") == 1)
          {
             Levelmanager.instance.lastLevelUnloked = 1; 
          }
          if (PlayerPrefs.GetInt("Player" + CharacterManager.instance.CurrentCharacter + "Didacticiel") == 0)
          {
              Levelmanager.instance.lastLevelUnloked = 2; 
          }
          
      }
      
      SceneManager.LoadSceneAsync("Level" + Levelmanager.instance.lastLevelUnloked);
       

        
    }

}
