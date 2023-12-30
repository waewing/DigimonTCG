using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveDeck : MonoBehaviour
{   
    public Button savebutton;

    public Button loadbutton;

    public CardCatalog deck;
    
    public TMP_InputField deckname;

    public TMP_Dropdown dropdown;


    public void SaveToJson()
    {
        string deckData = JsonUtility.ToJson(deck);
        // foreach(CardDisplay c in deck.catalog)
        // {
        //     deckData += JsonUtility.ToJson(c.card);
        // }
        string filePath = Application.persistentDataPath + "/" + deckname.text + ".json";
        System.IO.File.WriteAllText(filePath, deckData);
        Debug.Log("Save Created");
    }

    public void LoadfromJson()
    {
        string filePath = Application.persistentDataPath + "/" + dropdown.options[dropdown.value].text + ".json";
        string deckData = System.IO.File.ReadAllText(filePath);

        JsonUtility.FromJsonOverwrite(deckData,deck);
        foreach(CardDisplay c in deck.catalog)
        {
            Instantiate(c,deck.transform);
        }
        Debug.Log("Load Success");
    }

     private void FixedUpdate()
    {
        // foreach(CardDisplay c in deck.catalog)
        // {
        //     Debug.Log(c.card.cardName);
        // }
        savebutton.onClick.AddListener(SaveOnClick);
        loadbutton.onClick.AddListener(LoadOnClick);
    }

    void SaveOnClick()
    {
        SaveToJson();
    }
    void LoadOnClick()
    {
        LoadfromJson();
    }

}

