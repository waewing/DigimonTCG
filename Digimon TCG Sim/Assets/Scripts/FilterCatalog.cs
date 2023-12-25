using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FilterCatalog : MonoBehaviour
{
    public CardCatalog catalog;
    public TMP_InputField input;
    public string text;


    void Filter()
    {
        text = input.text;
        if(text != "")
        {
            foreach(CardDisplay card in catalog.catalog)
            {
                if(card.card.cardName.Contains(text))
                {
                    card.obj.SetActive(true);
                }
                else
                {
                    card.obj.SetActive(false);
                }
            }
        }
        else
        {
            foreach(CardDisplay card in catalog.catalog)
            {
            card.obj.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Filter();
    }
}
