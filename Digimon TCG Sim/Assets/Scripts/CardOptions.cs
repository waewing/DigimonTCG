using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOptions : MonoBehaviour
{
    public Button btn;
    public Button play;
    public Button activate;
    public Button digivolve;
    public Button battle;


    public GameObject card;
    public GameObject options;
    bool active = false;

    
    public void OptionPopup(){
        
        switch(GameSetup.curPhase)
        {
            case GamePhase.Setup:
                play.interactable = false;
                activate.interactable = false;
                digivolve.interactable = false;
                battle.interactable = false;
                break;
            case GamePhase.P1UnsuspendPhase:
                play.interactable = false;
                activate.interactable = false;
                digivolve.interactable = false;
                battle.interactable = false;
                break;
            case GamePhase.P1DrawPhase:
                play.interactable = false;
                activate.interactable = false;
                digivolve.interactable = false;
                battle.interactable = false;
                break;
            case GamePhase.P1BreedingPhase:
                play.interactable = true;
                activate.interactable = false;
                digivolve.interactable = false;
                battle.interactable = false;
                break;
            case GamePhase.P1MainPhase:
                play.interactable = true;
                activate.interactable = true;
                digivolve.interactable = true;
                battle.interactable = true;
                break;
            case GamePhase.P1EndPhase:
                play.interactable = true;
                activate.interactable = false;
                digivolve.interactable = false;
                battle.interactable = false;
                break;

        }
        

        if(active == false)
        {
            GameObject dupe = Instantiate(options, btn.transform);
            dupe.name = "PopUp Options";
            dupe.transform.position = card.transform.position;
            dupe.SetActive(true);
            if(dupe.transform.position.y >= 3f)
            {
                dupe.transform.Translate(0,-1.22f,0);
            }
            else
            {
                dupe.transform.Translate(0,1.22f,0);
            }
            active = true;
        }
        else
        {
            Destroy(card.transform.Find("PopUp Options").gameObject);
            active = false;
        }
    }



}
