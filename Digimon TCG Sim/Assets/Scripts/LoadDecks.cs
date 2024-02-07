using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadDecks : MonoBehaviour
{

    public TMP_Text box1;

    public TMP_Text box2;

    public Deck player1;
    public Deck player2;
    public Deck de_deck1;
    public Deck de_deck2;
    public Deck p1_hand;
    

    void Start()
    {
        box1.SetText(GoToGame.deck1);
        box2.SetText(GoToGame.deck2);

        LoadDeck(player1,de_deck1,GoToGame.deck1);
        LoadDeck(player2,de_deck2,GoToGame.deck2);
        FisherYatesShuffle(player1);
        foreach (var x in Enumerable.Range(0,5)) Draw(p1_hand,player1);
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
    void LoadDeck(Deck player_deck,Deck de_deck,string data)
    {
        //Load Main Deck
        foreach(string s in data.Split("DD:")[0].Split('\n'))
        {
            if(string.IsNullOrWhiteSpace(s) != true)
            {
                for(int i = 0; i < Convert.ToInt32(s.Split('x')[0]); i++)
                {
                    player_deck.deck.Add(Resources.Load<Card>("Cards/ST1/"+s.Split('x')[1]));
                }
            }
            else
            {
                continue;
            }
        }

        //Load Digi-Egg Deck
        foreach(string s in data.Split("DD:")[1].Split('\n'))
        {
            if(string.IsNullOrWhiteSpace(s) != true)
            {
                for(int i = 0; i < Convert.ToInt32(s.Split('x')[0]); i++)
                {
                    de_deck.deck.Add(Resources.Load<Card>("Cards/ST1/"+s.Split('x')[1]));
                }
            }
            else
            {
                continue;
            }
        }
    }

}
