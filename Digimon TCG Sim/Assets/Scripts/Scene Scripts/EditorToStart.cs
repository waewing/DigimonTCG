using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EditorToStart : MonoBehaviour
{
    public void GoTo()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}
