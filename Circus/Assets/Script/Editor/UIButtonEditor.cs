using UnityEngine;
using System.Collections;
using UnityEditor;
[CustomEditor(typeof(MapButton))]
public class UIButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapButton t = (MapButton)target;
    }
}
