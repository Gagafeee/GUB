using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Portal : MonoBehaviour

{
    
    
    [Range(0,3)]
    [Description("0 = menu, 1 = next game scene, 2 = crédit scene")]
    public int LevelType = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            EndLevelPanelManager.Instance.DisplayPanel();

        }
        
    }
    
}
