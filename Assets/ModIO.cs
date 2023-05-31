using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModIO{
    
    private Dictionary<string, bool> ModTypes = new Dictionary<string, bool>(){
        { "FloatVariable", true },
        { "FloatVariableRange", true }
    };

    public bool IsModTypeExist(string modType){
        return ModTypes.ContainsKey(modType);
    }

    public string ReadFile(string loadPath){
        // Does the file exist?
        if (File.Exists(loadPath)){
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(loadPath);
            return fileContents;
        }
        else{
            return "";
        }
    }
    
    // Deserialize the JSON data 
    //  into a pattern matching the GameData class.
    //JsonUtility.FromJsonOverwrite(fileContents, cubeTranslationData);
    //return true;
    
}