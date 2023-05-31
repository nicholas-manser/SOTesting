using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class Mod: MonoBehaviour
{
    public ModPublisher publisher;
    private ModIO modIO;
    private string loadPath;
    private List<FieldInfo> modFields = new List<FieldInfo>();
    public void Awake(){
        loadPath = Application.persistentDataPath;
        modIO = new ModIO();
        
        modFields = GetModdableFields();
        CheckForMods(modFields, loadPath);
        ApplyMods();
    }

    private List<FieldInfo> GetModdableFields(){
        List<FieldInfo> fields = new List<FieldInfo>();
        Type myType = this.GetType();
        FieldInfo[] myFields = myType.GetFields();
        foreach (FieldInfo fieldInfo in myFields){
            if (modIO.IsModTypeExist(fieldInfo.FieldType.ToString()))
            {
                fields.Add(fieldInfo);
            }
        }

        return fields;
    }

    private void CheckForMods(List<FieldInfo> modInfo, string modLoadPath){
        foreach (FieldInfo fieldInfo in modInfo){
            string modPath = modLoadPath + "/" + fieldInfo.Name;
            string mod = modIO.ReadFile(modPath);
            //if (mod.){
                
            //}
        }
    }

    private void ApplyMods(){
        
    }
    
    public void ExportToModsFolder(){
        throw new NotImplementedException();
    }

}
