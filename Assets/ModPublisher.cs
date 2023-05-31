using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ModPublisher : ScriptableObject{
    private List<Mod> subscribers = new List<Mod>();
    public void Raise(){
        for (int i = subscribers.Count -1; i >= 0; i--){
            subscribers[i].ExportToModsFolder();
        }
    }

    public void RegisterListener(Mod listener){
        subscribers.Add(listener);
    }

    public void UnregisterListener(Mod listener){
        subscribers.Remove(listener);
    }
    
}
