using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapGenerator3))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();
        MapGenerator3 map = target as MapGenerator3;
        map.generateMap();
    }
}
