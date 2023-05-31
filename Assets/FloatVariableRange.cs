using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariableRange : ScriptableObject{
    [Range(0,1)]
    public float Value;
}