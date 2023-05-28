using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpaceFlyingObject), true)]
[CanEditMultipleObjects]
public class SpaceFlyingObjectEditor : Editor
{
    private SerializedProperty _health;
    private SerializedProperty _reward;
    private SerializedProperty _canDeathNotfy;
    private SerializedProperty _enemyDeathNotifier;
    private SerializedProperty _bossDeathNotifier;
    private SerializedProperty _isBoss;
    private SerializedProperty _blink;
    private SerializedProperty _firstShootDelay;
    private SerializedProperty _canShoot;
    private SerializedProperty _shootPoint;
    private SerializedProperty _shootDelay;
    private SerializedProperty _bossPuff;

    private void OnEnable()
    {
        _health = serializedObject.FindProperty("_health");
        _reward = serializedObject.FindProperty("_reward");
        _enemyDeathNotifier = serializedObject.FindProperty("_enemyDeathNotifier");
        _bossDeathNotifier = serializedObject.FindProperty("_bossDeathNotifier");
        _isBoss = serializedObject.FindProperty("_isBoss");
        _blink = serializedObject.FindProperty("_blink");
        _canDeathNotfy = serializedObject.FindProperty("_canDeathNotfy");
        _firstShootDelay = serializedObject.FindProperty("_firstShootDelay");
        _canShoot = serializedObject.FindProperty("_canShoot");
        _shootPoint = serializedObject.FindProperty("_shootPoint");
        _shootDelay = serializedObject.FindProperty("_shootDelay");
        _bossPuff = serializedObject.FindProperty("_bossPuff");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_isBoss);
        if (_isBoss.boolValue)
        {
            ShowBaseFields();

            DrawLine();

            EditorGUILayout.PropertyField(_bossDeathNotifier);
            EditorGUILayout.PropertyField(_blink);
            EditorGUILayout.PropertyField(_bossPuff);
        }
        else
        {
            ShowBaseFields();

            DrawLine();

            EditorGUILayout.PropertyField(_canShoot);
            if (_canShoot.boolValue)
            {
                EditorGUILayout.PropertyField(_firstShootDelay);
                EditorGUILayout.PropertyField(_shootPoint);
                EditorGUILayout.PropertyField(_shootDelay);

            }

            EditorGUILayout.PropertyField(_canDeathNotfy);
            if (_canDeathNotfy.boolValue)
            {
                EditorGUILayout.PropertyField(_enemyDeathNotifier);
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowBaseFields()
    {
        EditorGUILayout.PropertyField(_health);
        EditorGUILayout.PropertyField(_reward);
    }

    private void DrawLine()
    {
        EditorGUILayout.Space(5);
        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
        EditorGUILayout.Space(5);
    }
}
