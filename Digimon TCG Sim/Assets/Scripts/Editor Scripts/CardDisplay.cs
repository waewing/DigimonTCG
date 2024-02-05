using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image artwork;
    public GameObject obj;

    void Start()
    {
        artwork.sprite = card.artwork;
    }

}
