using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ExportSOToJSON : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        string dir = Application.dataPath + "/SO";
        SaveSOTOJSON(dir, "test");
    }

    bool SaveSOTOJSON(string readPath, string savePath){
        Debug.Log("IN SaveSOTOJSON");
        //get all SOs in readPath directory, loop through each
        foreach (string file in Directory.EnumerateFiles(readPath)){
            //transform to JSON
            //TransformToJSON()
            //write JSON to savePath
            Debug.Log(file);
        }
        
        return false;
    }

    public string TransformToJSON(object obj){
        return JsonUtility.ToJson(obj);
    }
    
    /*public bool ReadFile()
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
    }*/
    
    /*public void WriteFile()
    {

        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(cubeTranslationData);

        // Write JSON to file.
        File.WriteAllText(saveFile, jsonString);
    }*/
}
