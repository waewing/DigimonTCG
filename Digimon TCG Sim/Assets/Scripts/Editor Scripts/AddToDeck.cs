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
        //Adds to deck area only if there are no more than 4 of the same card there and if the total amount of cards are at max 50
        if (end.name == "Deck" && end.catalog.Count < 50)
        {
            List<CardDisplay> sameName = end.catalog.FindAll(x => x.name == card.name + "(Clone)");
            if(sameName.Count < 4)
            {
                CardDisplay newcard = Instantiate(card,end.transform);
                newcard.GetComponent<AddToDeck>().start = end;
                newcard.GetComponent<AddToDeck>().end = start;
                newcard.GetComponent<AddToDeck>().card = newcard;
                end.catalog.Add(newcard);
            }
            else
            {
                Debug.Log("Card Limit Reached");
            }
        }

        // Adds to the digi-egg deck area only if there are no more than 4 copies of a card there and the total amount of cards does not exceed 5
        else if(end.name == "Digi-Egg Deck" && end.catalog.Count < 5)
        {
            List<CardDisplay> sameName = end.catalog.FindAll(x => x.name == card.name + "(Clone)");
            if(sameName.Count < 4)
            {
                CardDisplay newcard = Instantiate(card,end.transform);
                newcard.GetComponent<AddToDeck>().start = end;
                newcard.GetComponent<AddToDeck>().end = start;
                newcard.GetComponent<AddToDeck>().card = newcard;
                end.catalog.Add(newcard);
            }
            else
            {
                Debug.Log("Card Limit Reached");
            }
        }

        //Removes card from the deck area on click
        else if(start.name == "Deck")
        {
            int i = card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.IndexOf(card,0);
            card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.RemoveAt(i);
            Destroy(card.gameObject);
        }
        
        //Removes card from the digi-egg deck area on click
        else if(start.name == "Digi-Egg Deck")
        {
            int i = card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.IndexOf(card,0);
            card.GetComponent<AddToDeck>().start.GetComponent<CardCatalog>().catalog.RemoveAt(i);
            Destroy(card.gameObject);
        }
    }
}
