using System;
using UnityEditor;
using UnityEngine;
using static EditorGUIHelper;

[CustomEditor(typeof(PlayerShipLocomotor)), CanEditMultipleObjects]
public class PlayerShipLocomotorEditor : Editor
{
    SerializedProperty speed, col;
    private const string speedLbl = "Speed:";
    private const string colLbl = "Collider:";
    private const string settingsLbl = "Settings";

    private void OnEnable()
    {
        speed = serializedObject.FindProperty(nameof(PlayerShipLocomotor.Speed));
        col = serializedObject.FindProperty(nameof(PlayerShipLocomotor.Col));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //base.OnInspectorGUI();

        GUILayout.BeginHorizontal();
        {
            GUILayout.FlexibleSpace();
            GUILayout.Label(settingsLbl, GUI.skin.label, GUILayout.Width(CalculateLabelWidth(settingsLbl)));
            GUILayout.FlexibleSpace();
        }
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        {
            GUILayout.Label(speedLbl,GUILayout.Width(CalculateLabelWidth(speedLbl)));
            speed.floatValue = EditorGUILayout.FloatField(speed.floatValue);
            //====
            GUILayout.Space(5f);
            GUILayout.Label(colLbl,GUILayout.Width(CalculateLabelWidth(colLbl)));
            col.objectReferenceValue = (Collider2D)EditorGUILayout.ObjectField(col.objectReferenceValue, typeof(Collider2D), true);
        }
        GUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
    }
}
