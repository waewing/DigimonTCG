using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{

    public Deck p1_deck;
    public Deck p2_deck;
    public Deck p1_hand;
    public Deck p2_hand;
    public Deck p1_security;
    public Deck p2_security;

    void Start()
    {
        // FisherYatesShuffle(player1);
        // foreach (var x in Enumerable.Range(0,5)) Draw(p1_hand,player1);
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
