using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class DropdownHandler : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();

        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);

        List<string> decks = new List<string>();

        var fileinfo = dir.GetFiles();

        foreach(FileInfo file in fileinfo)
        {
            decks.Add(Path.GetFileNameWithoutExtension(file.Name));
        }

        dropdown.AddOptions(decks);

    }
}
