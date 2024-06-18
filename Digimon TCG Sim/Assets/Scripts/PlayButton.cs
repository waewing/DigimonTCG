using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public GameObject playedcard;
    public GameObject playArea;

    // Playbutton On Click will subtract the energy cost of the card from the current energy and will move the 
    // played card into the battle area, with summon sickness if a digimon, and normally if a tamer.
    public void summonCard()
    {   
        Debug.Log("Card Played");
        //If card is an options or tamer
        //Moves card to tamer area.
        if(playedcard.GetComponent<CardDisplay>().card.form == "Option" || playedcard.GetComponent<CardDisplay>().card.form == "Tamer")
        {
            playedcard.transform.position = playArea.transform.GetChild(1).transform.position;
            playedcard.transform.SetParent(playArea.transform.GetChild(1));
        }
        //Moves card to digimon area.
        else
        {
            playedcard.transform.position = playArea.transform.GetChild(0).transform.position;
            playedcard.transform.SetParent(playArea.transform.GetChild(0));
        }

        //Subtracts the cost of card from energy.
    }

}
