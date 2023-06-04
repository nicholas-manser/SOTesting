using UnityEngine;

public class CubeMove : Mod{
    
    [SerializeField]
    public FloatVariableRange translationSpeed;

    // Update is called once per frame
    void Update(){
        transform.position = Vector3.zero + transform.right * Mathf.Sin(Time.time * translationSpeed.Value);
    }
}
