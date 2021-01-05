using AngryLab;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveGamePref))]
public class SaveGamePrefEditorDrawer : Editor
{
    // Used to draw the button on the editor
    public override void OnInspectorGUI()
    {
        SaveGamePref savePref = (SaveGamePref)target;
        base.OnInspectorGUI();

        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Save Settings"))
        {
            savePref.SaveSettings();
        }

        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("Load Settings"))
        {
            savePref.LoadSettings();
        }
    }

}
