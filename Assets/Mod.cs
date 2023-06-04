using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class Mod: MonoBehaviour
{
    public ModPublisher publisher;
    private ModIO _modIO;
    private string _loadPath;
    private string _exportPath;
    public void Awake(){
        _loadPath = Application.persistentDataPath + "/Mods";
        _modIO = new ModIO();
        publisher.RegisterListener(this);

        List<ModIO.ModdableField> modFields = GetModdableFields(_modIO);
        List<ModIO.ModDefinition> serialisedMods = CheckForMods(modFields, _loadPath);
        ApplyMods(serialisedMods, _modIO);
    }

    public void OnDisable(){
        publisher.UnregisterListener(this);
    }

    private List<ModIO.ModdableField> GetModdableFields(ModIO modInOut){
        List<ModIO.ModdableField> modFields = new List<ModIO.ModdableField>();
        Type myType = this.GetType();
        FieldInfo[] myFields = myType.GetFields();
        foreach (FieldInfo fieldInfo in myFields){
            if (modInOut.IsModTypeExist(fieldInfo.FieldType.ToString())){
                object myObj = fieldInfo.GetValue(this);
                string name = myObj.GetType().GetProperty("name").GetValue(myObj).ToString();
                ModIO.ModdableField modField = new ModIO.ModdableField(name, myObj);
                modFields.Add(modField);
            }
        }

        return modFields;
    }

    private List<ModIO.ModDefinition> CheckForMods(List<ModIO.ModdableField> modInfo, string modLoadPath){
        List<ModIO.ModDefinition> serialisedMods = new List<ModIO.ModDefinition>();

        foreach (ModIO.ModdableField moddableField in modInfo){
            string modPath = modLoadPath + "/" + moddableField.Name + ".json";
            string mod = _modIO.ReadFile(modPath);
            if (mod != ""){
                ModIO.ModDefinition addModDef = new ModIO.ModDefinition(moddableField.Name, mod, moddableField.ObjectRef);
                serialisedMods.Add(addModDef);
            }
        }

        return serialisedMods;
    }

    private void ApplyMods(List<ModIO.ModDefinition> serialisedMods, ModIO modIO){
        foreach (ModIO.ModDefinition modDefinition in serialisedMods){
            modIO.OverwriteModFieldWithMod(modDefinition.SerialisedData, modDefinition.ObjectRef);
        }
    }
    
    public void ExportToModsFolder(){
        List<ModIO.ModdableField> modFields = GetModdableFields(_modIO);
        foreach (ModIO.ModdableField moddableField in modFields){
            string serialisedMod = _modIO.TransformToJSON(moddableField.ObjectRef);
            _modIO.WriteFile(_loadPath + "/" + moddableField.Name + ".json", serialisedMod);
        }
        
    }

}
