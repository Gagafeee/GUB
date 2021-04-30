using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SignDetect : MonoBehaviour
{
    public bool DisplayText;
    public string TextToDisplay;
    public GameObject TextOBJ;
    public Text Text;
    public Animator Animator;


    public bool isDidacticiel;
    public bool displayDirectonalKeys;
    public bool displaySpaceKey;
    public bool displayCointCountArrow;
    
    public void Start()
    {
        Text.text = TextToDisplay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text.text = TextToDisplay;
            StartCoroutine(FadeIn());
            if (isDidacticiel)
            {
                Didacticiel.instance.DisplayDidacticielPanel(displayDirectonalKeys, displaySpaceKey, displayCointCountArrow);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (isDidacticiel)
            {
                Didacticiel.instance.RemoveDisplayDidacticielPanel();
            }
            StartCoroutine(FadeOut());
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text.text = TextToDisplay;
            StartCoroutine(FadeIn());
            if (isDidacticiel)
            {
                Didacticiel.instance.DisplayDidacticielPanel(displayDirectonalKeys, displaySpaceKey, displayCointCountArrow);
            }
        }
    }

    private IEnumerator FadeIn()
    {
        TextOBJ.SetActive(true);
        Animator.SetTrigger("FadeIN");
        yield return new WaitForSeconds(0.25f);
        DisplayText = true;
    }

    private IEnumerator FadeOut()
    {
        Animator.SetTrigger("FadeOUT");
        yield return new WaitForSeconds(0.6f);
        TextOBJ.SetActive(false);
        DisplayText = false;
    }
}
