using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour
{
    public static string buttonText;

    public bool state = false;

    public Button updatingButton;
    public Button endTurn;

    public Deck p1_deck;

    public Deck p1_hand;

    public Deck p2_deck;

    public Deck p2_hand;     

    public GameObject card;
    
    public AudioSource drawSound;

    void Update()
    {
        switch(GameSetup.curPhase)
        {
            //End Turn uninteractable until Battle Phase

            //Unsuspend Phases
            case GamePhase.P1UnsuspendPhase:
                endTurn.interactable = false;
                buttonText = "P1 Unsuspend";
                break;
            case GamePhase.P2UnsuspendPhase:
                endTurn.interactable = false;
                buttonText = "P2 Unsuspend";
                break;

            //Draw Phases
            case GamePhase.P1DrawPhase:
                endTurn.interactable = false;
                if(GameSetup.turnNumber == 1)
                {
                    buttonText = "Go To Breeding Phase";
                }
                else
                {
                    buttonText = "P1 Draw";
                }
                break;
            case GamePhase.P2DrawPhase:
                endTurn.interactable = false;
                if(GameSetup.turnNumber == 1)
                {
                    buttonText = "Go To Breeding Phase";
                }
                else
                {
                    buttonText = "P2 Draw";
                }
                break;

            //Breeding Phase
            case GamePhase.P1BreedingPhase:
                updatingButton.onClick.RemoveListener(P1Draw);
                endTurn.interactable = false;
                buttonText = "P1 Breed";
                break;
            case GamePhase.P2BreedingPhase:
                updatingButton.onClick.RemoveListener(P2Draw);
                endTurn.interactable = false;
                buttonText = "P2 Breed";
                break;

            //Main Phases
            case GamePhase.P1MainPhase:
                endTurn.interactable = true;
                buttonText = "";
                break;
            case GamePhase.P2MainPhase:
                endTurn.interactable = true;
                buttonText = "";
                break;
        }
    }

    void P1Draw()
    {
        GameSetup.Draw(p1_hand, p1_deck);
        GameObject dupe = Instantiate(card,p1_hand.transform); 
        drawSound.Play();
        dupe.SetActive(true);
        dupe.GetComponent<CardDisplay>().card = p1_hand.deck[^1];
    }
    void P2Draw()
    {
        GameSetup.Draw(p2_hand, p2_deck);
        GameObject dupe = Instantiate(card,p2_hand.transform); 
        drawSound.Play();
        dupe.SetActive(true);
        dupe.GetComponent<CardDisplay>().card = p2_hand.deck[^1];
    }

    public void PhaseHandler()
    {
        switch(GameSetup.curPhase)
        {
            //Unsuspend
            //Unsuspend all cards in battle area then got to next phase
            case GamePhase.P1UnsuspendPhase:
                GameSetup.curPhase = GamePhase.P1DrawPhase;
                if (GameSetup.turnNumber >= 2)
                {
                    updatingButton.onClick.AddListener(P1Draw);
                }
                break;
            case GamePhase.P2UnsuspendPhase:
                GameSetup.curPhase = GamePhase.P2DrawPhase;
                if (GameSetup.turnNumber >= 2)
                {
                    updatingButton.onClick.AddListener(P2Draw);
                }
                break;

            
            //Draw
            //If turn 1 go to next phase
            //Otherwise draw 1 card from top of deck
            case GamePhase.P1DrawPhase:
                GameSetup.curPhase = GamePhase.P1BreedingPhase;
                break;
            case GamePhase.P2DrawPhase:
                GameSetup.curPhase = GamePhase.P2BreedingPhase;
                break;


            //Breed
            //Player chooses either to select a breeding option or go to next phase
            case GamePhase.P1BreedingPhase:
                GameSetup.curPhase = GamePhase.P1MainPhase;
                break;
            case GamePhase.P2BreedingPhase:
                GameSetup.curPhase = GamePhase.P2MainPhase;
                break;


            //Main
            // Do main phase stuff (attacking, digivolving, ending turn etc.)
            // case GamePhase.P1MainPhase:
            //     GameSetup.curPhase = GamePhase.P1EndPhase;
            //     break;
            // case GamePhase.P2MainPhase:
            //     GameSetup.curPhase = GamePhase.P2EndPhase;
            //     break;
            
        }
    }

    public void EndTurn()
    {
        switch(GameSetup.curPhase)
        {
            case GamePhase.P1MainPhase:
                GameSetup.curPhase = GamePhase.P2UnsuspendPhase;
                GameSetup.turnNumber += 1;
                break;
            case GamePhase.P2MainPhase:
                GameSetup.curPhase = GamePhase.P1UnsuspendPhase;
                GameSetup.turnNumber += 1;
                break;
        }
    }

    //Draw a card from top of deck
    //If cannot draw player loses
    //Turn 1, the first player does not draw
    public void DrawPhase()
    {
       return;
    }

    //Option of either Hatching an Egg, Moving out of Breeding Area, or doing nothing
    //Hatch - Play top card of digiegg deck, treated as a level 2 digimon
    //Move - Can only be moved if it has DP, effects like On Play don't trigger, can attack the same turn it moves
    //Do Nothing -  Skips phase
    public void BreedingPhase()
    {
        return;
    }

    //Can perform any option in any desired order.
    //Playing Digimon, Digivolving, Playing Tamers, Using option cards, Attacking, Activating [Main] effects
    //Each options has further rules governing
    public void MainPhase()
    {
        return;
    }


    //If memory counter goes past zero, due to costs or other effects, your turn ends and it becomes your oppenents turn.
    //After all effects finish activating, the turn passes.
    //If an effect causes the counter to return to 0 or higher, your turn proceeds
    //If your turn is declared over, set memory counter to 3 on your opponents side.
    public void EndPhase()
    {
        return;
    }

}
