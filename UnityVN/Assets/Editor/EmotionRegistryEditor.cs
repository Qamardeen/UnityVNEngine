using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.IO;

[CustomEditor(typeof(EmotionRegistry))]
public class EmotionRegistryEditor : Editor
{
    private EmotionRegistry _emotionRegistry;
	private ReorderableList _list;

	private void OnEnable()
	{
		_emotionRegistry = serializedObject.targetObject as EmotionRegistry;

		_list = new ReorderableList(
			serializedObject, serializedObject.FindProperty("_emotionNames"),
			true, true, true, true);

		_list.drawElementCallback = DrawElementCallback;
	}

	private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
    {
		var element = _list.serializedProperty.GetArrayElementAtIndex(index);
		rect.y += 2;
		EditorGUI.LabelField(new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight), "Emotion " + index);
		EditorGUI.PropertyField(
			new Rect(rect.x + 60, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
			element, GUIContent.none);
	}

	public override void OnInspectorGUI()
	{
		serializedObject.UpdateIfRequiredOrScript();

		_list.DoLayoutList();

		_emotionRegistry.EmotionEnumScript = 
			EditorGUILayout.ObjectField(_emotionRegistry.EmotionEnumScript, typeof(MonoScript), false) as MonoScript;

		if (GUILayout.Button("Save"))
        {
			SaveToFile();
        }

		serializedObject.ApplyModifiedProperties();
	}

	private void SaveToFile()
	{
		if (_emotionRegistry.EmotionEnumScript == null)
        {
			Debug.LogError("Specified Script Not Found");
			return;
        }

		string assetPath = AssetDatabase.GetAssetPath(_emotionRegistry.EmotionEnumScript);
		while (assetPath.Contains("\\"))
        {
			assetPath.Replace("\\", "/");
		}
		assetPath = assetPath.Substring(0, assetPath.LastIndexOf("/") + 1);

		string name = _emotionRegistry.EmotionEnumScript.name;

		List<string> emotions = new List<string>(_emotionRegistry.EmotionNames);
		EditorMethods.WriteToEnum(assetPath, name, emotions);
	}


}
