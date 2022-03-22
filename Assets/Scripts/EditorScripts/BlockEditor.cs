using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BlockData))]
public class BlockEditor : Editor
{
    public override void OnInspectorGUI(){
        //base.OnInspectorGUI();
        BlockData block_data = (BlockData)target;
        GUILayout.Label("Start position", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("X:");
        block_data.x_start = EditorGUILayout.IntField("", 
        block_data.x_start, GUILayout.MaxWidth(200));
        GUILayout.Label("Z:");
        block_data.z_start = EditorGUILayout.IntField("", 
        block_data.z_start, GUILayout.MaxWidth(200));
        GUILayout.EndHorizontal();
        GUILayout.Label("End position", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("X:");
        block_data.x_end = EditorGUILayout.IntField("", 
        block_data.x_end, GUILayout.MaxWidth(200));
        GUILayout.Label("Z:");
        block_data.z_end = EditorGUILayout.IntField("", 
        block_data.z_end, GUILayout.MaxWidth(200));
        GUILayout.EndHorizontal();
        GUILayout.Label("Size", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("X:");
        block_data.size_x = EditorGUILayout.IntField("", 
        block_data.size_x, GUILayout.MaxWidth(200));
        GUILayout.Label("Z:");
        block_data.size_z = EditorGUILayout.IntField("", 
        block_data.size_z, GUILayout.MaxWidth(200));
        GUILayout.EndHorizontal();
    }
}
