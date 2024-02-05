using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZoomDisplay : MonoBehaviour
{

    public Image obj1;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public CardDisplay display;

    void OnMouseEnter()
    {
        obj1.sprite = display.card.artwork;
        text.text = "Effect:\n" + display.card.effect;
        text2.text = "Inherited Effect:\n" + display.card.inheritedEffect;
    }
    
}
