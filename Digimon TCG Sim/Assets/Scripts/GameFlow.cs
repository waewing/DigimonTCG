using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    void Update()
    {
        switch(GameSetup.curPhase)
        {
            case GamePhase.P1UnsuspendPhase:
                Debug.Log("P1 First");
                break;
            case GamePhase.P2UnsuspendPhase:
                Debug.Log("P2 First");
                break;
        }
    }


    //Unsuspend all cards on your side of the field
    public void UnsuspendPhase()
    {
        return;
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
