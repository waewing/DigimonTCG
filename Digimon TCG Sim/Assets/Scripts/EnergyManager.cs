using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    private int currentEnergy = 0;
    private const int MAX_ENERGY = 10;
    private const int DEFAULT_ENERGY = 3;


    private void Start()
    {
        ModifyEnergy(DEFAULT_ENERGY);
    }

    public bool ModifyEnergy(int amount)
    {
        int newEnergy = currentEnergy + amount;
        if(newEnergy > MAX_ENERGY || newEnergy < -MAX_ENERGY)
        {
            return false;
        }

        currentEnergy = newEnergy;
        return true;
    }

    public int GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public bool CanPlayCard(int cost)
    {
        //If the cost is greater than the max energy plus the current energy, the card cannot be played.
        //e.g If the card cost 15, and the current energy is 4, the card cannot be played. Energy would go to 11 which is out of bounds.
        //e.g If the card cost 15, and the current energy is 5, the card can be played. Energy would go to 10 which is within bounds.
        if (currentEnergy > 0){
            return cost <= MAX_ENERGY+Mathf.Abs(currentEnergy);
        }
        else{
            return false;
        }
    }
}
