using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModIO{

    public struct ModDefinition{
        public ModDefinition(string name, string serialisedData, object objectRef){
            Name = name;
            SerialisedData = serialisedData;
            ObjectRef = objectRef;
        }
        
        public string Name{ get; }
        public string SerialisedData{ get; }
        public object ObjectRef{ get; }
    }
    
    public struct ModdableField{
        public ModdableField(string name, object objectRef){
            Name = name;
            ObjectRef = objectRef;
        }
        
        public string Name{ get; }
        public object ObjectRef{ get; }
    }
    
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

    public void WriteFile(string exportPath, string serialisedObj){
        File.WriteAllText(exportPath, serialisedObj);
    }

    public void OverwriteModFieldWithMod(string serialisedData, object objectToOverwrite){
        JsonUtility.FromJsonOverwrite(serialisedData, objectToOverwrite);
    }
    
    public string TransformToJSON(object obj){
        return JsonUtility.ToJson(obj);
    }
    
}