using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToDeck : MonoBehaviour
{
    public CardDisplay card;
    public CardCatalog end;
    public CardCatalog start;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (end.name == "Deck" && end.catalog.Count < 50)
        {
            CardDisplay newcard = Instantiate(card,end.transform);
            newcard.GetComponent<AddToDeck>().start = end;
            newcard.GetComponent<AddToDeck>().end = start;
            newcard.GetComponent<AddToDeck>().card = newcard;
            end.catalog.Add(newcard);
            
        }

        else if(end.name == "Digi-Egg Deck" && end.catalog.Count < 5)
        {
            CardDisplay newcard = Instantiate(card,end.transform);
            newcard.GetComponent<AddToDeck>().start = end;
            newcard.GetComponent<AddToDeck>().end = start;
            newcard.GetComponent<AddToDeck>().card = newcard;
            end.catalog.Add(newcard);
        }

        else if(start.name == "Deck")
        {
            int i = card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.IndexOf(card,0);
            card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.RemoveAt(i);
            Destroy(card.gameObject);
        }
        
        else if(start.name == "Digi-Egg Deck")
        {
            int i = card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.IndexOf(card,0);
            card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.RemoveAt(i);
            Destroy(card.gameObject);
        }
    }
}
