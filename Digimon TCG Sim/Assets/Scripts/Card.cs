using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
   public Sprite artwork;
   public string cardName;
   public int playCost;
   public string color;
   public int digivolveCost;
   public int DP;
   public int level;
   public string form;
   public string digiAttribute;
   public string type;
   public string rarity;
   public string code;
   public string digivolveColor;
   public string effect;
   public string inheritedEffect;
   public string specialDigivolution;
   public int digivolveLevel;
}
