using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ModPublisher : ScriptableObject{

    private List<Mod> _subscribers = new List<Mod>();

    public void Raise(){

        for (int i = _subscribers.Count -1; i >= 0; i--){
            _subscribers[i].ExportToModsFolder();
        }
    }

    public void RegisterListener(Mod listener){
        _subscribers.Add(listener);
    }

    public void UnregisterListener(Mod listener){
        _subscribers.Remove(listener);
    }
    
}
