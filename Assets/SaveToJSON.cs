using System.IO;
using UnityEngine;

public class SaveToJSON : MonoBehaviour
{
    // Create a field for the save file.
    string saveFile;
    
    // Create a FloatVariable field.
    FloatVariable cubeTranslationData;

    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.dataPath);
        Debug.Log(Application.streamingAssetsPath);
        cubeTranslationData = ScriptableObject.CreateInstance<FloatVariable>();
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/cubeTranslationData.json";

        WriteFile();
    }

    public void WriteFile()
    {

        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(cubeTranslationData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }
}