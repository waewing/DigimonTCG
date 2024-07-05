using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoToAnyScene : MonoBehaviour
{
     void Start()
    {
        Debug.Log("Loaded Scene");
    }
    public void GoTo(string sceneName)

    {
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    
}
