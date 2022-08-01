using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(CharacterData))]
public class CharacterEditor : Editor
{

    private CharacterData _characterData;
    private ReorderableList _list;

    private void OnEnable()
    {
        _characterData = serializedObject.targetObject as CharacterData;

        _list = new ReorderableList(
             serializedObject, serializedObject.FindProperty("_emotionMappings"),
             true, true, true, true);

        _list.drawElementCallback = DrawElementCallback;
    }

    private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
    {
        var element = _list.serializedProperty.GetArrayElementAtIndex(index);
        rect.y += 2;

        EditorGUI.PropertyField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), 
            element.FindPropertyRelative("Emotion"), GUIContent.none);
        EditorGUI.PropertyField(new Rect(rect.x + 200, rect.y, rect.width - 200 - 30, EditorGUIUtility.singleLineHeight), 
            element.FindPropertyRelative("Image"), GUIContent.none);


    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        _characterData.Name = EditorGUILayout.TextField("Character Name", _characterData.Name);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Character Prefab");
        _characterData.Prefab = EditorGUILayout.ObjectField(_characterData.Prefab, typeof(GameObject), false) as GameObject;
        EditorGUILayout.EndHorizontal();

        _list.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
    }

}
