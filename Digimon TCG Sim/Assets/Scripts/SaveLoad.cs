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
    
    public TMP_InputField deckname;

    public TMP_Dropdown dropdown;


    
    public void SaveToJson()
    {
        Dictionary<string,int> dict = new Dictionary<string,int>();
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
    
        string deckData = "";
        foreach(KeyValuePair<string,int> s in dict)
        {
            deckData += s.Value.ToString() + "x" + s.Key + "\n";
        }
        string filePath = Application.persistentDataPath + "/" + deckname.text + ".deck";
        // System.IO.File.WriteAllText(filePath, string.Empty);
        // foreach(CardDisplay c in deck.catalog)
        // {
        //     string deckData = JsonUtility.ToJson(c.card);
        //     System.IO.File.AppendAllText(filePath, deckData);
        // }
        // string filePath = Application.persistentDataPath + "/" + deckname.text + ".json";
        System.IO.File.WriteAllText(filePath, deckData);
        Debug.Log("Save Created," + filePath.ToString());
    }

    public void LoadfromJson()
    {
        deck.catalog.Clear();
        foreach (Transform child in deck.transform)
        {
            Destroy(child.gameObject);
        }
        string filePath = Application.persistentDataPath + "/" + dropdown.options[dropdown.value].text + ".deck";
        string deckData = System.IO.File.ReadAllText(filePath);

        foreach(string s in deckData.Split('\n'))
        {
            for(int i = 0; i < Convert.ToInt32(s.Split('x')[0]); i++)
            {
                CardDisplay newcard = Instantiate(card,deck.transform);
                newcard.GetComponent<AddToDeck>().end = newcard.GetComponent<AddToDeck>().start;
                newcard.GetComponent<AddToDeck>().start = deck;
                newcard.GetComponent<AddToDeck>().card = newcard;
                newcard.name = s.Split('x')[1];
                newcard.GetComponent<CardDisplay>().card = Resources.Load<Card>("Assets/Cards/Cards/ST-01/"+s.Split('x')[1]);
                deck.catalog.Add(newcard);
            }
            // Debug.Log(s);
        }
        // foreach(CardDisplay c in deck.catalog)
        // {
        //     Instantiate(c,deck.transform);
        // }
        Debug.Log("Load Success");
    }

}

