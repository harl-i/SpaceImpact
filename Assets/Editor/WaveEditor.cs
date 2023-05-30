using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Wave), true)]
[CanEditMultipleObjects]
public class WaveEditor : Editor
{
    private SerializedProperty _transitions;
    private SerializedProperty _spawnDelay;
    private SerializedProperty _enemiesSpeed;
    private SerializedProperty _enemiesPool;
    private SerializedProperty _spawnPoints;
    private SerializedProperty _waypoints;
    private SerializedProperty _moveVariant;
    private SerializedProperty _isBossWave;
    private SerializedProperty _boss;
    private SerializedProperty _canLunge;
    private SerializedProperty _lungeWaypoints;
    private SerializedProperty _hasSecondaryWeapon;
    private SerializedProperty _hasBonus;
    private SerializedProperty _bonus;
    private SerializedProperty _bonusSpeed;
    private SerializedProperty _canVerticalMoveBonus;


    private void OnEnable()
    {
        _transitions = serializedObject.FindProperty("_transitions");
        _spawnDelay = serializedObject.FindProperty("_spawnDelay");
        _enemiesSpeed = serializedObject.FindProperty("_enemiesSpeed");
        _enemiesPool = serializedObject.FindProperty("_enemiesPool");
        _spawnPoints = serializedObject.FindProperty("_spawnPoints");
        _waypoints = serializedObject.FindProperty("_waypoints");
        _moveVariant = serializedObject.FindProperty("_moveVariant");
        _isBossWave = serializedObject.FindProperty("_isBossWave");
        _boss = serializedObject.FindProperty("_boss");
        _canLunge = serializedObject.FindProperty("_canLunge");
        _hasSecondaryWeapon = serializedObject.FindProperty("_hasSecondaryWeapon");
        _lungeWaypoints = serializedObject.FindProperty("_lungeWaypoints");
        _hasBonus = serializedObject.FindProperty("_hasBonus");
        _bonus = serializedObject.FindProperty("_bonus");
        _bonusSpeed = serializedObject.FindProperty("_bonusSpeed");
        _canVerticalMoveBonus = serializedObject.FindProperty("_canVerticalMoveBonus");
    }

    public override void OnInspectorGUI()
    {
        GUIContent lungeLabel = new GUIContent("Lunge waypoints");
        GUIContent PatrolLabel = new GUIContent("Patrol waypoints");

        serializedObject.Update();

        EditorGUILayout.PropertyField(_isBossWave);

        if (_isBossWave.boolValue)
        {
            EditorGUILayout.PropertyField(_boss);
            EditorGUILayout.PropertyField(_waypoints, PatrolLabel);

            EditorGUILayout.PropertyField(_canLunge);
            if (_canLunge.boolValue)
            {
                EditorGUILayout.PropertyField(_lungeWaypoints, lungeLabel);
            }
            else
            {
                _lungeWaypoints.ClearArray();
            }

            EditorGUILayout.PropertyField(_hasSecondaryWeapon);
        }
        else
        {
            DrawLine();
            EditorGUILayout.PropertyField(_hasBonus);
            if (_hasBonus.boolValue)
            {
                EditorGUILayout.PropertyField(_canVerticalMoveBonus);
                EditorGUILayout.PropertyField(_bonus);
                EditorGUILayout.PropertyField(_bonusSpeed);
            }
            else
            {
                _canVerticalMoveBonus.boolValue = false;
                _bonus.objectReferenceValue = null;
                _bonusSpeed.floatValue = 0;
            }
            DrawLine();

            _boss.objectReferenceValue = null;
            switch (_moveVariant.enumValueIndex)
            {
                case (int)MoveVariants.Linear:
                    ShowLinearMoveFields();
                    break;
                case (int)MoveVariants.Chaotic:
                    ShowChaoticMoveFields();
                    break;
                case (int)MoveVariants.Points:
                    ShowPointsMoveFields();
                    break;
                case (int)MoveVariants.Patrol:
                    ShowPatrolMoveFields();
                    break;
                case (int)MoveVariants.Lunge:
                    ShowLungeMoveFields();
                    break;
                default:
                    break;
            }

            DrawLine();
            EditorGUILayout.PropertyField(_transitions);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawLine()
    {
        EditorGUILayout.Space(5);
        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1), Color.gray);
        EditorGUILayout.Space(5);
    }

    private void ShowLinearMoveFields()
    {
        ShowBaseFields();
    }


    private void ShowChaoticMoveFields()
    {
        ShowBaseFields();
    }

    private void ShowPointsMoveFields()
    {
        ShowBaseFields();
        EditorGUILayout.PropertyField(_waypoints);
    }

    private void ShowPatrolMoveFields()
    {
        ShowBaseFields();
        EditorGUILayout.PropertyField(_waypoints);
    }

    private void ShowLungeMoveFields()
    {
        EditorGUILayout.PropertyField(_moveVariant);
        EditorGUILayout.HelpBox("Этот варинт движения не используется для мобов", MessageType.Info);
    }

    private void ShowBaseFields()
    {
        EditorGUILayout.PropertyField(_spawnDelay);
        EditorGUILayout.PropertyField(_enemiesSpeed);
        EditorGUILayout.PropertyField(_enemiesPool);
        EditorGUILayout.Space(10);
        EditorGUILayout.PropertyField(_spawnPoints);
        EditorGUILayout.Space(10);
        EditorGUILayout.PropertyField(_moveVariant);
    }
}
