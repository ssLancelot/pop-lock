using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameData))]
public class GameDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameData e = target as GameData;

        if (GUILayout.Button("Reset Data"))
        {
            e.ResetData();
        }

    }
}
