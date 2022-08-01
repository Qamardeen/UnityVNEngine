using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private string _name;
    public string Name {
        get { return _name ; }
        set { _name = value; }
    }

    [SerializeField]
    private GameObject _prefab;
    public GameObject Prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }

    [SerializeField]
    private EmotionMapping[] _emotionMappings;
    public EmotionMapping[] EmotionMappings
    {
        get { return _emotionMappings; }
    }

}

[Serializable]
public struct EmotionMapping
{
    public Emotion Emotion;
    public Image Image;
}
