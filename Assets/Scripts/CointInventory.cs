using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CointInventory : MonoBehaviour
{

    public int coinsCount;
    public Text coinsCountText;
    public Text CointAddText;
    public GameObject CointAddObject;
    public static CointInventory instance;
    public int u;
    
    public Statistic statistic;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {

        coinsCountText.text = coinsCount.ToString();
        Inventory.inventory.CointQTText.text = coinsCount.ToString();
        u = coinsCount;
        

    }


    public void AddCoins(int count)
    {

        statistic.collectedCoins += count;
        StartCoroutine(AddCointAnnimations(count));


        //   GraphiqueAddCointActive(count);

    }

    public IEnumerator AddCointAnnimations(int count)
    {
        for (int a = count; a > 0; a--)
        {
            coinsCount = coinsCount + 1;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        //CharacterManager.instance.Save();
    }

    public IEnumerator RemoveCoint(int count)
    {
        for (int a = count; a > 0; a--)
        {
            coinsCount = coinsCount - 1;
            yield return new WaitForSeconds(0.01f);
        }
    }



    /* public void GraphiqueAddCointActive(int count)
     {
         CointAddObject.GetComponent<Animator>().enabled = true;
         CointAddObject.SetActive(true);
         CointAddText.text = ("+ " + count);

     }

     public void GraphiqueAddCointUnactive(int count)
     {

         CointAddObject.SetActive(false);
         CointAddObject.GetComponent<Animator>().enabled = false;
         CointAddText.text = ("+ 0");

     }
    */


    /*  public void DataLoad(string Value)
      {
          AddCoins(int.Parse(Value));
      }
      */
}
