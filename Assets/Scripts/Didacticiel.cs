using System;
using System.Collections;
using UnityEngine;

public class Didacticiel : MonoBehaviour
{
    public static Didacticiel instance;
    public Animator Animator;
    public Animator DirectionalKeyAnimator;
    public Animator DisplaySpaceKeyAnimator;
    public Animator DisplayCointCountArrowAnimator;

    private void Awake()
    {
        instance = this;
    }

    public void DisplayDidacticielPanel(bool DisplayDirectionalKeys, bool DisplaySpaceKey, bool DisplayCointCountArrow)
    {
        //DisplayDirectionalKeys
        if (DisplayDirectionalKeys)
        {
            DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", true);
        }

        if (DisplayDirectionalKeys == false)
        {
            DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", false);
        }
        
        //DisplaySpaceKey
        if (DisplaySpaceKey)
        {
            DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", true);
        }

        if (DisplaySpaceKey == false)
        {
            DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", false);
        }

        if (DisplayCointCountArrow)
        {
            DisplayCointCountArrowAnimator.SetBool("isVisible", true);
        }
        if (DisplayCointCountArrow == false)
        {
            DisplayCointCountArrowAnimator.SetBool("isVisible", false);
        }
            

        Animator.SetBool("isVisible", true);
    }

    public void RemoveDisplayDidacticielPanel()
    {
        Animator.SetBool("isVisible", false);
        DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", false);
        DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", false);
        DisplayCointCountArrowAnimator.SetBool("isVisible", false);
    }


        
  
}
