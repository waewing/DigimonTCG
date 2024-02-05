using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToEditor : MonoBehaviour
{
    public void GoTo()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
}
