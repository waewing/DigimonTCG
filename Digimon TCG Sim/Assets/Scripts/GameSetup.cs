using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSetup : MonoBehaviour
{

    public Deck p1_deck;
    public Deck p2_deck;
    public Deck p1_hand;
    public Deck p2_hand;
    public Deck p1_security;
    public Deck p2_security;
    public GameObject card;

    void Start()
    {
        FisherYatesShuffle(p1_deck);
        FisherYatesShuffle(p2_deck);
        StartingDraw(p1_hand,p1_deck);
        StartingDraw(p2_hand,p2_deck);
        
    }

    //Draws 5 to players hand
    void StartingDraw(Deck destination, Deck start)
    {
        foreach (int x in Enumerable.Range(0,5)) Draw(destination,start);
        foreach (int x in Enumerable.Range(0,5)){
        GameObject dupe = Instantiate(card,destination.transform); 
        dupe.SetActive(true);
        dupe.GetComponent<CardDisplay>().card = destination.deck[x];
        }
    }
    void Draw(Deck destination,Deck start)
    {
        destination.deck.Add(start.deck[0]);
        start.deck.RemoveAt(0);
    }
    
    void FisherYatesShuffle(Deck d)
    {
        var rand = new System.Random();
        int index = 0;
        Card temp;
        for(int i = d.deck.Count-1; i > 0; i--)
        {
            index = rand.Next(i+1);
            if(index == i)
            {
                continue;
            }
            else
            {
                temp = d.deck[index];
                d.deck[index] = d.deck[i];
                d.deck[i] = temp;
            }
        }
    }
}
