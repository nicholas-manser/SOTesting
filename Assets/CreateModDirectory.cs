using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateModDirectory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateModFolder("Mods");
    }

    // Update is called once per frame
    void CreateModFolder(string folderName)
    {
        if (Directory.Exists(folderName)){
            //do nothing
            return;
        }
        
        Directory.CreateDirectory(Application.persistentDataPath + "/" + folderName);
    }
}
