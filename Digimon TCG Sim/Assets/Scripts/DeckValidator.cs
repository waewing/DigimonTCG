using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeckValidator : MonoBehaviour
{
    public TMP_Dropdown p1choice;

    public TMP_Dropdown p2choice;

    public Button btn;

    void Update()
    {
        RunValidate();
    }

    public bool Validate(TMP_Dropdown dropdown)
    {
        int sum = 0;
        string filePath = Application.persistentDataPath + "/" + dropdown.options[dropdown.value].text + ".deck";
        string deckData = System.IO.File.ReadAllText(filePath);

        foreach(string s in deckData.Split('\n'))
        {
            if(string.IsNullOrWhiteSpace(s) == true)
            {
                break;
            }
            if(s == "DD:")
            {
                if(sum != 50 )
                {
                   return false;
                }
                continue;
            }
            else
            {
                if(Convert.ToInt32(s[0].ToString()) > 4)
                {
                    return false;
                }
                else
                {
                    sum += Convert.ToInt32(s[0].ToString());
                }
            }
        }

        if(sum > 54)
        {
            return false;
        }

        return true;

    }

    public void RunValidate()
    {
        if(Validate(p1choice) == true & Validate(p2choice) == true)
        {
            btn.interactable = true;
        }
        else
        {
            btn.interactable = false;
        }
    }
}
