using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToDeck : MonoBehaviour
{
    public CardDisplay card;
    public CardCatalog destination;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (destination.name == "Deck" && destination.catalog.Count < 50)
        {
            destination.catalog.Add(card);
            CardDisplay newcard = Instantiate(card,destination.transform);
        }
        else if(destination.name == "Digi-Egg Deck" && destination.catalog.Count < 5)
        {
            destination.catalog.Add(card);
            CardDisplay newcard = Instantiate(card,destination.transform);
        }
    }
}
