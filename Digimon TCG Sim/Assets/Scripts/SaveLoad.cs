using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDeck : MonoBehaviour
{   

    public CardDisplay card;

    public Button savebutton;

    public Button loadbutton;

    public CardCatalog deck;

    public CardCatalog de_deck;
    
    public TMP_InputField deckname;

    public TMP_Dropdown dropdown;


    //Create a dictionary dict to count occurences of a card in the deck
    //Create a string deckdata, adding from our dict the occurences of each card into the string in the format XxST-XX
    //Write to a created file on unity persistant data path
    public void SaveToJson()
    {
        string deckData = "";
        Dictionary<string,int> dict = new Dictionary<string,int>();

        //Add deck cards
        foreach(CardDisplay c in deck.catalog)
        {
            if (dict.ContainsKey(c.card.ToString().Split(' ')[0]))
            {
                dict[c.card.ToString().Split(' ')[0]] += 1;
            }
            else
            {
                dict.Add(c.card.ToString().Split(' ')[0],1);
            }
            
        }
        
        //Add deck cards to deckdata with x seperator
        foreach(KeyValuePair<string,int> s in dict)
        {
            deckData += s.Value.ToString() + "x" + s.Key + "\n";
        }

        dict.Clear();

        //Add digiegg cards
        foreach(CardDisplay c in de_deck.catalog)
        {
            if (dict.ContainsKey(c.card.ToString().Split(' ')[0]))
            {
                dict[c.card.ToString().Split(' ')[0]] += 1;
            }
            else
            {
                dict.Add(c.card.ToString().Split(' ')[0],1);
            }
        }

        //Add a delimiter line before the digiegg deck is added
        deckData += "DD:\n";

        //Add digiegg cards to deckdata with x seperator
        foreach(KeyValuePair<string,int> s in dict)
        {
            deckData += s.Value.ToString() + "x" + s.Key + "\n";
        }


        string filePath = Application.persistentDataPath + "/" + deckname.text + ".deck";
        System.IO.File.WriteAllText(filePath, deckData);
        Debug.Log("Save Created," + filePath.ToString());
    }

    //Clear wahtever we have in deck area first
    // Load into deckdata the selected file
    //Break up the string by each line
    //Break each line up by the delimiter character (x for deck or y for digiegg deck)
    //Load the card with its name and card object of its name
    public void LoadfromJson()
    {
        //Clearing both deck areas first
        deck.catalog.Clear();
        de_deck.catalog.Clear();
        foreach (Transform child in deck.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in de_deck.transform)
        {
            Destroy(child.gameObject);
        }


        //Load string information from file into deckdata
        string filePath = Application.persistentDataPath + "/" + dropdown.options[dropdown.value].text + ".deck";
        string deckData = System.IO.File.ReadAllText(filePath);


        //Load Cards before DD: delimiter
        foreach(string s in deckData.Split("DD:")[0].Split('\n'))
        {
            if(string.IsNullOrWhiteSpace(s) != true)
            {
                for(int i = 0; i < Convert.ToInt32(s.Split('x')[0]); i++)
                {
                    CardDisplay newcard = Instantiate(card,deck.transform);
                    newcard.GetComponent<AddToDeck>().end = newcard.GetComponent<AddToDeck>().start;
                    newcard.GetComponent<AddToDeck>().start = deck;
                    newcard.GetComponent<AddToDeck>().card = newcard;
                    newcard.name = s.Split('x')[1];
                    newcard.GetComponent<CardDisplay>().card = Resources.Load<Card>("Cards/ST1/"+s.Split('x')[1]);
                    deck.catalog.Add(newcard);
                }
            }
            else
            {
                continue;
            }
        }

        
        //Load Cards after DD: delimiter
        foreach(string s in deckData.Split("DD:")[1].Split('\n'))
        {
            if(string.IsNullOrWhiteSpace(s) != true)
            {
                for(int i = 0; i < Convert.ToInt32(s.Split('x')[0]); i++)
                {
                    CardDisplay newcard = Instantiate(card,de_deck.transform);
                    newcard.GetComponent<AddToDeck>().end = newcard.GetComponent<AddToDeck>().start;
                    newcard.GetComponent<AddToDeck>().start = de_deck;
                    newcard.GetComponent<AddToDeck>().card = newcard;
                    newcard.name = s.Split('x')[1];
                    newcard.GetComponent<CardDisplay>().card = Resources.Load<Card>("Cards/ST1/"+s.Split('x')[1]);
                    de_deck.catalog.Add(newcard);
                }
            }
            else
            {
                continue;
            }
        }
        Debug.Log("Load Success");
    }

}

