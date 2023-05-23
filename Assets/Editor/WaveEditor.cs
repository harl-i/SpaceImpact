using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor
{
    private Wave _wave;

    private SerializedProperty _parentWayPoints = null;

    private void OnEnable()
    {
        _wave = (Wave)target;

        _parentWayPoints = serializedObject.FindProperty("_parentWayPoints");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_parentWayPoints);
    }
}
