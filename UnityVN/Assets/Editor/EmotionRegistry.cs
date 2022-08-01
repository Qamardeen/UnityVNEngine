using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EmotionRegistry : ScriptableSingleton<EmotionRegistry>
{
    [SerializeField]
    private string[] _emotionNames;
    public string[] EmotionNames
    {
        get { return _emotionNames; }
    }

    [SerializeField]
    private MonoScript _emotionEnumScript;
    public MonoScript EmotionEnumScript
    {
        get { return _emotionEnumScript; }
        set { _emotionEnumScript = value; }
    }
}
