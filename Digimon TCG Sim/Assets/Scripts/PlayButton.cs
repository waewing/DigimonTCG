using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public GameObject playedcard;
    public GameObject playArea;
    public EnergyManager EnergyManager;


    // Playbutton On Click will subtract the energy cost of the card from the current energy and will move the 
    // played card into the battle area, with summon sickness if a digimon, and normally if a tamer.
    public void summonCard()
    {   
        int cardCost = playedcard.GetComponent<CardDisplay>().card.playCost;
        bool canPlayCard = EnergyManager.CanPlayCard(cardCost);
        
        if(canPlayCard)
        {
            //If card is an options or tamer
            //Moves card to tamer area.
            if(playedcard.GetComponent<CardDisplay>().card.form == "Option" || playedcard.GetComponent<CardDisplay>().card.form == "Tamer")
            {
                playedcard.transform.position = playArea.transform.GetChild(1).transform.position;
                playedcard.transform.SetParent(playArea.transform.GetChild(1));
                EnergyManager.ModifyEnergy(-cardCost);
                Debug.Log("Card Played" + cardCost + " " + EnergyManager.GetCurrentEnergy());
            }
            //Moves card to digimon area.
            else
            {
                playedcard.transform.position = playArea.transform.GetChild(0).transform.position;
                playedcard.transform.SetParent(playArea.transform.GetChild(0));
                EnergyManager.ModifyEnergy(-cardCost);
                Debug.Log("Card Played" + cardCost + " " + EnergyManager.GetCurrentEnergy());
            }
        }
        else
        {   
            Debug.Log("Not enough energy to play card " + cardCost + " " + EnergyManager.GetCurrentEnergy());
        }

    }

}
