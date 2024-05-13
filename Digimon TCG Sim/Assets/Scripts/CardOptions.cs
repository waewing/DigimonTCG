using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardOptions : MonoBehaviour
{
    public Button btn;
    public GameObject card;
    public GameObject options;
    bool active = false;

    public void OptionPopup(){
        if(active == false)
        {
            GameObject dupe = Instantiate(options,btn.transform);
            dupe.name = "PopUp Options";
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
