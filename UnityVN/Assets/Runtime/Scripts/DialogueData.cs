using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueData
{
    [SerializeField]
    private CharacterData _characterData;

    [SerializeField] 
    private Emotion _emotion;

    [SerializeField] 
    [Multiline]
    private string _text;
    public string Text {
        get { return _text; }
        set { _text = value; }
    }

    

}
