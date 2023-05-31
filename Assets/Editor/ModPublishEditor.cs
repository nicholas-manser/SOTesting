using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(ModPublisher))]
public class ModPublishEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ModPublisher myScript = (ModPublisher)target;
        if(GUILayout.Button("Export to Mods Folder"))
        {
            myScript.Raise();
        }
    }
}
