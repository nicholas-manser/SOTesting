using System;
using System.IO;
using UnityEngine;

public class LoadMods : MonoBehaviour
{
    // Create a field for the load file.
    string loadFile;
    
    // Create a FloatVariable field.
    public FloatVariable cubeTranslationData;
    public GameObject go;

    public void Awake(){
        Debug.Log(Application.persistentDataPath);
        loadFile = Application.persistentDataPath + "/cubeTranslationData.json";
        ReadFile();
        ApplyTranslationToCube();
    }

    void ApplyTranslationToCube(){
        CubeMove cubeMove = go.GetComponent<CubeMove>();
        cubeMove.translationSpeed.Value = cubeTranslationData.Value;
    }

    public bool ReadFile()
    {
        // Does the file exist?
        if (File.Exists(loadFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(loadFile);
            
            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            JsonUtility.FromJsonOverwrite(fileContents, cubeTranslationData);
            return true;
        }
        else{
            return false;
        }
    }
}
