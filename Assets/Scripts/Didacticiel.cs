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
        


        switch (DisplayDirectionalKeys)
        {
            //DisplayDirectionalKeys
            case true:
                DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", true);
                Animator.SetBool("isVisible", true);
                break;
            case false:
                DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", false);
                break;
        }

        switch (DisplaySpaceKey)
        {
            //DisplaySpaceKey
            case true:
                DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", true);
                Animator.SetBool("isVisible", true);
                break;
            case false:
                DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", false);
                break;
        }

        switch (DisplayCointCountArrow)
        {
            case true:
                DisplayCointCountArrowAnimator.SetBool("isVisible", true);
                break;
            case false:
                DisplayCointCountArrowAnimator.SetBool("isVisible", false);
                break;
        }
    }

    public void RemoveDisplayDidacticielPanel()
    {
        Animator.SetBool("isVisible", false);
        DirectionalKeyAnimator.SetBool("DisplayDirectionalKeysFlashing", false);
        DisplaySpaceKeyAnimator.SetBool("DisplaySpaceKeyFlashing", false);
        DisplayCointCountArrowAnimator.SetBool("isVisible", false);
    }


        
  
}
