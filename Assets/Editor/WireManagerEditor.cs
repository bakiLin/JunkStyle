using UnityEditor;

[CustomEditor(typeof(WireManager))]
public class WireManagerEditor : Editor
{
    #region SerializedProperty
    SerializedProperty connectedWire;
    SerializedProperty orWireManager;
    SerializedProperty andWireManager;
    SerializedProperty notWireManager;
    SerializedProperty tvWireManager;
    SerializedProperty orIndex;
    SerializedProperty andIndex;
    SerializedProperty type;

    bool notGroup, orGroup, andGroup, tvGroup = false;
    #endregion

    private void OnEnable()
    {
        connectedWire = serializedObject.FindProperty("connectedWire");
        orWireManager = serializedObject.FindProperty("orWireManager");
        andWireManager = serializedObject.FindProperty("andWireManager");
        notWireManager = serializedObject.FindProperty("notWireManager");
        tvWireManager = serializedObject.FindProperty("tvWireManager");
        orIndex = serializedObject.FindProperty("orIndex");
        andIndex = serializedObject.FindProperty("andIndex");
        type = serializedObject.FindProperty("type");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(type);
        EditorGUILayout.PropertyField(connectedWire);

        orGroup = EditorGUILayout.BeginFoldoutHeaderGroup(orGroup, "OR");
        if (orGroup)
        {
            EditorGUILayout.PropertyField(orWireManager);
            EditorGUILayout.PropertyField(orIndex);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        andGroup = EditorGUILayout.BeginFoldoutHeaderGroup(andGroup, "AND");
        if (andGroup)
        {
            EditorGUILayout.PropertyField(andWireManager);
            EditorGUILayout.PropertyField(andIndex);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        notGroup = EditorGUILayout.BeginFoldoutHeaderGroup(notGroup, "NOT");
        if (notGroup) EditorGUILayout.PropertyField(notWireManager);
        EditorGUILayout.EndFoldoutHeaderGroup();

        tvGroup = EditorGUILayout.BeginFoldoutHeaderGroup(tvGroup, "TV");
        if (tvGroup) EditorGUILayout.PropertyField(tvWireManager);
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
