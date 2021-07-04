using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Portal : MonoBehaviour

{
    
    
    [Range(0,3)]
    [Description("0 = menu, 1 = next game scene, 2 = crédit scene")]
    public int LevelType = 0;

    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            AudioManager.instance.PlayClipAt(sound, transform.position);
            EndLevelPanelManager.Instance.DisplayPanel();
            CurrentSceneManager.instance.UpdatePos(gameObject);
            CurrentSceneManager.instance.SetRespawnPoint(gameObject.transform.position);
            CurrentSceneManager.instance.isTheFirstEnterInLevel = false;
            LoadAndSaveData.instance.SaveData();

        }
        
    }
    
}
