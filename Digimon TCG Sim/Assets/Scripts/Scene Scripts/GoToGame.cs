using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToGame : MonoBehaviour
{
    public TMP_Dropdown p1choice;

    public TMP_Dropdown p2choice;

    public static string deck1;
    public static string deck2;

    

    public void GoTo()
    {
        string filePath = Application.persistentDataPath + "/" + p1choice.options[p1choice.value].text + ".deck";
        deck1 = System.IO.File.ReadAllText(filePath);
        filePath = Application.persistentDataPath + "/" + p2choice.options[p2choice.value].text + ".deck";
        deck2 = System.IO.File.ReadAllText(filePath);
        SceneManager.LoadScene(sceneBuildIndex:3);
    }
}
